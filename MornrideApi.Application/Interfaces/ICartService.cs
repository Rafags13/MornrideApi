using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.RedisModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Application.Interfaces
{
    public interface ICartService
    {
        public Task<IEnumerable<BikeCart?>> GetAllCartItems();
        public Task<bool> AddItem(AddBikeDto bikeDto);
        public BikeCart GetBikeInCartByHisId(int id);
        public IEnumerable<BikeCart?> GetBikesByIds(int[] id);
    }
}
