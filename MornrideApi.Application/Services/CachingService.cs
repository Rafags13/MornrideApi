using Microsoft.Extensions.Caching.Distributed;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.RedisModels;
using Redis.OM.Searching;
using Redis.OM;
using MornrideApi.Domain.Entities.Dto;
using Arch.EntityFrameworkCore.UnitOfWork;
using MornrideApi.Domain.Entities.Model;
using Microsoft.EntityFrameworkCore;
using MornrideApi.Domain.Entities.Enums;

namespace MornrideApi.Application.Services
{
    public class CachingService : ICachingService
    {
        private readonly RedisCollection<BikeCart> _bikeCart;
        private readonly RedisConnectionProvider _provider;
        private readonly IUnitOfWork _unitOfWork;
        public CachingService(RedisConnectionProvider provider, IUnitOfWork unitOfWork)
        {
            _provider = provider;
            _bikeCart = (RedisCollection<BikeCart>) provider.RedisCollection<BikeCart>();
            _unitOfWork = unitOfWork;
        }

        public async Task AddBikeIntoCart(BikeCart bikeDto)
        {
            var bikeAlsoExistsInCart = await _bikeCart.FindByIdAsync(bikeDto.Id.ToString());

            if (bikeAlsoExistsInCart != null)
            {
                bikeAlsoExistsInCart.Amount = bikeDto.Amount; // updates the current value to new value in cache
                await _bikeCart.UpdateAsync(bikeAlsoExistsInCart);

            } else
            {
                await AddBikeIntoCacheByLastReferente(bikeDto);
            }
        }

        private async Task AddBikeIntoCacheByLastReferente(BikeCart bikeDto)
        {
            var newBikeCart = new BikeCart
            {
                Id = bikeDto.Id,
                ImageUrl = bikeDto.ImageUrl,
                Title = bikeDto.Title,
                Amount = bikeDto.Amount,
                Price = bikeDto.Price,
                AvaliableColors = bikeDto.AvaliableColors
            };

            await _bikeCart.InsertAsync(newBikeCart);
        }

        public async Task AddCurrentBikesIntoCart(IEnumerable<BikeCart> bikes)
        {
            await _bikeCart.InsertAsync(bikes);
        }

        public async Task<IEnumerable<BikeCart?>> GetAllItems()
        {
            return await _bikeCart.ToListAsync();
        }

        public async Task<BikeCart?> GetBikeCardById(string id)
        {
            return await _bikeCart.FindByIdAsync(id);
        }
    }
}
