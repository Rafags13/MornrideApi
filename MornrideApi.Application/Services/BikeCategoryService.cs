using Arch.EntityFrameworkCore.UnitOfWork;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Application.Services
{
    public class BikeCategoryService : IBikeCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BikeCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> CreateLinkForBike(CreateLinkBikeCategoryDto createLinkBikeCategoryDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IBikeCategoryService>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
