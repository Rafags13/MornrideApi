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
    public class BikeImageService : IBikeImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BikeImageService(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateBikeImage(CreateBikeImageDto bikeImageDto)
        {
            var newBikeImage = new BikeImage { HexColor = bikeImageDto.HexColor, BikeId = bikeImageDto.BikeId, ImageId = bikeImageDto.ImageId, ImagePosition = bikeImageDto.ImagePosition };

            _unitOfWork.GetRepository<BikeImage>().Insert(newBikeImage);

            var successfull = await _unitOfWork.SaveChangesAsync() > 0;

            return successfull;
        }

        public async Task<List<BikeImage>> GetAll()
        {
            var allBikeImages = await _unitOfWork.GetRepository<BikeImage>().GetPagedListAsync(include: x => x.Include(p => p.Bike).Include(p => p.Image));

            return allBikeImages.Items.ToList();
        }
    }
}
