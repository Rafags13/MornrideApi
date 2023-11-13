using Arch.EntityFrameworkCore.UnitOfWork;
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
            return true;
        }
    }
}
