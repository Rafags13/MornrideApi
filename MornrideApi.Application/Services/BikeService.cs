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

        public IEnumerable<HomeBikeDto> GetBikesByCategory(string collection)
        {
            throw new NotImplementedException();
        }
    }
}
