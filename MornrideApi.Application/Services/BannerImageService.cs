using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.Model;

namespace MornrideApi.Application.Services
{
    public class BannerImageService : IBannerImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BannerImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateImage(CreateBannerImageDto createBannerImageDto)
        {
            var newBannerImage = new BannerImage
            {
                Label = createBannerImageDto.Label,
                Collection = createBannerImageDto.Collection,
                ImageId = createBannerImageDto.ImageBannerId
            };

            _unitOfWork.GetRepository<BannerImage>().Insert(newBannerImage);

            var success = await _unitOfWork.SaveChangesAsync() > 0;

            return success;
        }

        public async Task<IEnumerable<BannerImage>> GetAll()
        {
            var counting = _unitOfWork.GetRepository<BannerImage>().Count();
            var allBannerImages = await _unitOfWork.GetRepository<BannerImage>().GetPagedListAsync(pageSize: counting, include: x => x.Include(x => x.ImageFromBanner));

            return allBannerImages.Items;
        }
    }
}
