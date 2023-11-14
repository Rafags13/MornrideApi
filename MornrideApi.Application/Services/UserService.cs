using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.Model;
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
                .Select(x => new HomeCategoryDto { Name = x.Name, DisplayName = x.DisplayName});

            var bikes =
                _unitOfWork.GetRepository<Bike>()
                .GetPagedList(pageSize: 5, include:
                    x => x.Include(x => x.BikeCategories)
                            .ThenInclude(category => category.Category)
                        .Include(x => x.BikeImages))
                .Items
                .Select(x => new HomeBikeDto {
                    Id = x.Id, Title = x.Title,
                    AvaliableColors = x.AvaliableColors,
                    CategoryNames = x.BikeCategories
                        .Select(b => b.Category.Name),
                    Price = x.Price,
                    Stock = x.Stock });

            return new HomeUserInformations { Banners = banners, Categories = categories, Bikes = bikes};
        }
    }
}
