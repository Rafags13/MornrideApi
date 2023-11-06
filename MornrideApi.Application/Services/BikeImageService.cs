using Arch.EntityFrameworkCore.UnitOfWork;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Application.Services
{
    public class BikeImageService : IBikeImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BikeImageService(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }
        public List<BikeImage> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
