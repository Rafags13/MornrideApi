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
    public class BikeService : IBikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BikeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<HomeBikeDto> GetBikesByCategory(string collection)
        {
            throw new NotImplementedException();
        }
    }
}
