using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Application.Interfaces
{
    public interface IBikeCategoryService
    {
        public Task<IEnumerable<BikeCategory>> GetAll();
        public Task<bool> CreateLinkForBike(CreateBikeCategoryDto createLinkBikeCategoryDto);
    }
}
