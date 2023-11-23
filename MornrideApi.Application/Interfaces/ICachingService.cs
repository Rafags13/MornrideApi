using Microsoft.AspNetCore.Mvc;
using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.RedisModels;

namespace MornrideApi.Application.Interfaces
{
    public interface ICachingService
    {
        public Task<IEnumerable<BikeCart?>> GetAllItems();
        public Task AddBikeIntoCart(BikeCartDto bikeCartDto);
        public Task AddCurrentBikesIntoCart(IEnumerable<BikeCart> bikes);
        public Task<BikeCart?> GetBikeCardById(string id);
    }
}
