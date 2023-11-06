using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Application.Interfaces
{
    public interface IBikeImageService
    {
        public Task<List<BikeImage>> GetAll();
        public Task<bool> CreateBikeImage(CreateBikeImageDto bikeImageDto);
    }
}
