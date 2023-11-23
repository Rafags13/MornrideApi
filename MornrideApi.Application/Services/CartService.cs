using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Application.Services
{
    public class CartService : ICartService
    {
        public CartService() { }

        public Task<bool> AddItem(int bikeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BikeCartDto>> GetAllCartItems()
        {
            throw new NotImplementedException();
        }
    }
}
