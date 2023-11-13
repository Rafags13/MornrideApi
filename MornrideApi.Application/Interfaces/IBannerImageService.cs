using MornrideApi.Domain.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Application.Interfaces
{
    public interface IBannerImageService
    {
        public Task<bool> CreateImage(CreateBannerImageDto createBannerImageDto);
    }
}
