using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.Enums;
using MornrideApi.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Application.Services
{
    public class BikeService : IBikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BikeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddBike(CreateBikeDto bikeDto)
        {
            var newBike = new Bike { Title = bikeDto.Title, Description = bikeDto.Description, Price = bikeDto.Price, Stock = bikeDto.Stock };
            _unitOfWork.GetRepository<Bike>().Insert(newBike);

            var success = await _unitOfWork.SaveChangesAsync() > 0;

            return success;
        }

        public IEnumerable<HomeBikeDto> GetAll()
        {
            var count = _unitOfWork.GetRepository<Bike>().Count();
            var allBikes = _unitOfWork.GetRepository<Bike>().GetPagedList(
                include: x =>
                    x.Include(y => y.BikeCategories)
                        .ThenInclude(bikeCategory => bikeCategory.Category)
                    .Include(y => y.BikeImages).ThenInclude(images => images.Image),
                pageSize: count)
                .Items.Select(x => new HomeBikeDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Price = x.Price,
                    Stock = x.Stock,
                    AvaliableColors = x.AvaliableColors,
                    CategoryNames = x.BikeCategories.Select(y => y.Category.Name),
                    ImageDiplayBikeUrl = x.BikeImages.FirstOrDefault(y => y.ImagePosition == PositionOfBikeImage.FullBike).Image.Url ?? ""
                });

            if (allBikes == null || !allBikes.Any())
            {
                throw new Exception("Não existe nenhuma bike no sistema.");
            }

            return allBikes;
        }

        public BikeDetailsDto GetBikeDetails(int bikeId)
        {
            var currentBike =
                _unitOfWork.GetRepository<Bike>()
                .GetFirstOrDefault(predicate: x => x.Id == bikeId,
                include: x => x.Include(bikeImage => bikeImage.BikeImages).ThenInclude(image => image.Image)
                    .Include(bikeCategory => bikeCategory.BikeCategories).ThenInclude(category => category.Category));

            if (currentBike == null)
            {
                throw new Exception("Desculpe, não foi possível encontrar a bike requisitada. Por favor, Contacte um administrador.");
            }

            var informations = CreateModelFromBikeInformations(currentBike);

            return informations;
        }

        private BikeDetailsDto CreateModelFromBikeInformations(Bike bikeSearched)
        {
            var bikeInformations = new BikeDetailsDto
            {
                Title = bikeSearched.Title,
                Price = bikeSearched.Price,
                Stock = bikeSearched.Stock,
                Description = bikeSearched.Description,
                Categories = bikeSearched!.BikeCategories!.Select(x => x.Category)!.Select(names => names.Name),
                AvaliableColors = bikeSearched?.AvaliableColors ?? Enumerable.Empty<string>(),
                Images = bikeSearched.BikeImages.Select(x => new BikeImagesProfileDto { ImageUrl = x.Image.Url, Position = x.ImagePosition})
            };

            return bikeInformations;
        }

        public IEnumerable<HomeBikeDto> GetBikesByCategory(string collection)
        {
            var count = _unitOfWork.GetRepository<Bike>().Count();

            var bikes =
                _unitOfWork.GetRepository<Bike>()
                .GetPagedList(pageSize: count,
                predicate: x => x.BikeCategories.Select(bikeCategory => bikeCategory.Category.Name).Contains(collection), 
                include: x =>
                x.Include(y => y.BikeCategories)
                    .ThenInclude(category => category.Category)
                .Include(y => y.BikeImages)
                    .ThenInclude(image => image.Image))
                .Items
                .Select(x => new HomeBikeDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Price = x.Price,
                    Stock = x.Stock,
                    AvaliableColors = x.AvaliableColors,
                    CategoryNames = x.BikeCategories?.Select(y => y.Category.Name),
                    ImageDiplayBikeUrl = x.BikeImages?.FirstOrDefault(predicate: bikeImage => bikeImage.ImagePosition == PositionOfBikeImage.FullBike)?.Image?.Url ?? ""
                });

            if(bikes == null || !bikes.Any())
            {
                throw new Exception("Essa categoria não possui nenhuma bike no momento.");
            }

            return bikes;
        }

        public IEnumerable<string?> GetAvaliableBikeNames()
        {
            var bikeNames = _unitOfWork.GetRepository<Bike>().GetPagedList().Items.Select(x => x.Title);

            if (!(bikeNames.Any()))
            {
                throw new Exception("Nenhuma bike foi encontrada");
            }

            return bikeNames;
        }

        public IEnumerable<HomeBikeDto?> GetBikesByName(string title)
        {
            var bikes =
                _unitOfWork.GetRepository<Bike>()
                .GetPagedList(
                    predicate: x => x.Title.Contains(title),
                    include: x => x
                        .Include(bike => bike.BikeCategories)
                            .ThenInclude(category => category.Category)
                        .Include(bikeImage => bikeImage.BikeImages)
                            .ThenInclude(image => image.Image)
                        )
                .Items
                .Select(x => new HomeBikeDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Price = x.Price,
                    Stock = x.Stock,
                    AvaliableColors = x.AvaliableColors,
                    CategoryNames = x.BikeCategories.Select(x => x.Category.Name),
                    ImageDiplayBikeUrl = x.BikeImages.FirstOrDefault(predicate: x => x.ImagePosition == PositionOfBikeImage.FullBike).Image.Url ?? ""
                });

            if (!bikes.Any())
            {
                throw new Exception("Não existe nenhuma bike com esse nome.");
            }

            return bikes;
        }
    }
}
