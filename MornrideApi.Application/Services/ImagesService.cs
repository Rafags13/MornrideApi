using Arch.EntityFrameworkCore.UnitOfWork;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.Model;

namespace MornrideApi.Application.Services { 
    public class ImagesService : IImagesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ImagesService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> UploadImage(CreateImageDto image)
        {
            if (image == null)
            {
                throw new Exception("Não é possível inserir uma imagem vazia.");
            }

            var newImage = new Image { Url = image.Url, Description = image.Description };
            _unitOfWork.GetRepository<Image>().Insert(newImage);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<List<Image>> GetImages()
        {
            var images = await _unitOfWork.GetRepository<Image>().GetPagedListAsync();

            return images.Items.ToList();
        }
    }
}
