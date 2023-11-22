using Microsoft.AspNetCore.Mvc;
using MornrideApi.Domain.Entities.RedisModels;

namespace MornrideApi.Application.Interfaces
{
    public interface ICachingService
    {
        public Task<IEnumerable<BikeCart?>> GetAllItems();
        public Task AddBikeIntoCart(BikeCart bikeCart);
        public Task<BikeCart?> GetBikeCardById(string id);
    }
}
