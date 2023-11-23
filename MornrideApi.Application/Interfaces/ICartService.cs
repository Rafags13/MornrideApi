using MornrideApi.Domain.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Application.Interfaces
{
    public interface ICartService
    {
        public Task<IEnumerable<BikeCartDto>> GetAllCartItems();
        public Task<bool> AddItem(int bikeId);
    }
}
