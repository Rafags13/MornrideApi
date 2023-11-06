using MornrideApi.Domain.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Application.Interfaces
{
    public interface IBikeCategoryService
    {
        public Task<IEnumerable<IBikeCategoryService>> GetAll();
        public Task<bool> CreateLinkForBike(CreateLinkBikeCategoryDto createLinkBikeCategoryDto);
    }
}
