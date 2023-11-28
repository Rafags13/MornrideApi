using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.Enums;
using MornrideApi.Domain.Entities.Model;
using MornrideApi.Domain.Entities.RedisModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserProfileInformations GetProfileInformations()
        {
            var lastSeenBikes = _unitOfWork.GetRepository<Bike>().GetPagedList(
                include: x =>
                    x.Include(y => y.BikeCategories)
                        .ThenInclude(bikeCategory => bikeCategory.Category)
                    .Include(y => y.BikeImages).ThenInclude(images => images.Image))
                .Items.Select(x => new HomeBikeDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Price = x.Price,
                    Stock = x.Stock,
                    AvaliableColors = x.AvaliableColors,
                    CategoryNames = x.BikeCategories.Select(y => y.Category.Name),
                    ImagesFromBikeByColor =
                    x.BikeImages
                        .Where(x => x.ImagePosition == PositionOfBikeImage.FullBike)
                        .Select(image => new BikeImageByColorDto { HexColor = image.HexColor, ImageUrl = image?.Image?.Url ?? "" })
                }).Take(3);

            var lastPurchaseBike = _unitOfWork.GetRepository<Bike>().GetFirstOrDefault(include: x => x.Include(y => y.BikeImages).ThenInclude(images => images.Image));

            var bikeCart = new BikeCart
            {
                Id = lastPurchaseBike.Id,
                Amount = 3,
                AvaliableColors = lastPurchaseBike?.AvaliableColors.ToArray() ?? Array.Empty<string>(),
                ImageUrl = lastPurchaseBike?.BikeImages?.FirstOrDefault(predicate: x => x.ImagePosition == PositionOfBikeImage.FullBike)?.Image?.Url ?? "",
                Title = lastPurchaseBike?.Title ?? "",
                Price = lastPurchaseBike.Price
            };

            var informations = new UserProfileInformations
            {
                IsPremiumMember = true,
                LastPurchaseBike = bikeCart,
                Name = "Rafael Veiga",
                LastSeenBikes = lastSeenBikes,
                YearsFromContribute = 3
            };

            return informations;
        }

        public HomeUserInformations GetHomeInformations()
        {
            var banners =
                _unitOfWork.GetRepository<BannerImage>()
                .GetPagedList(include:
                    x => x.Include(x => x.ImageFromBanner))
                .Items
                .Select(x => new HomeBannerDto {
                    ImageUrl = x.ImageFromBanner?.Url ?? "",
                    Description = x.Label,
                    Collection = x.Collection });

            var categories =
                _unitOfWork.GetRepository<Category>()
                .GetPagedList()
                .Items
                .Select(x => new HomeCategoryDto { Name = x.Name, DisplayName = x.DisplayName})
                .OrderBy(x => x.Name);

            var bikes =
                _unitOfWork.GetRepository<Bike>()
                .GetPagedList(pageSize: 5, include:
                    x => x.Include(x => x.BikeCategories)   
                            .ThenInclude(category => category.Category)
                        .Include(x => x.BikeImages)
                        .ThenInclude(bikeImage => bikeImage.Image)
                        )
                .Items
                .Select(x => new HomeBikeDto {
                    Id = x.Id, Title = x.Title,
                    AvaliableColors = x.AvaliableColors,
                    ImagesFromBikeByColor = x.BikeImages
                        .Where(x => x.ImagePosition == PositionOfBikeImage.FullBike)
                        .Select(image => new BikeImageByColorDto { HexColor = image.HexColor, ImageUrl = image?.Image?.Url ?? "" }),
                    CategoryNames = x.BikeCategories?
                        .Select(b => b.Category!.Name),
                    Price = x.Price,
                    Stock = x.Stock });

            return new HomeUserInformations { Banners = banners, Categories = categories, Bikes = bikes};
        }
    }
}
