using Arch.EntityFrameworkCore.UnitOfWork;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.Model;

namespace MornrideApi.Application.Services { 
    public class ImagesService : ImgService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ImagesService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> UploadImage(CreateImageDto image)
        {
            var newImageFromBike = new Image {
                HexColor = image.HexColor,
                BackWheel = image.BackWheel, 
                FrontBike = image.FrontBike,
                FrontWheel = image.FrontWheel,
                FullBike = image.FullBike,
                BikeId = image.BikeId
            
            };

            _unitOfWork.GetRepository<Image>().Insert(newImageFromBike);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<List<Image>> GetImages()
        {
            var images = await _unitOfWork.GetRepository<Image>().GetPagedListAsync();

            return images.Items.ToList();
        }
    }
}
