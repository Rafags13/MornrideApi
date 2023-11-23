using Microsoft.Extensions.Caching.Distributed;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.RedisModels;
using Redis.OM.Searching;
using Redis.OM;
using MornrideApi.Domain.Entities.Dto;

namespace MornrideApi.Application.Services
{
    public class CachingService : ICachingService
    {
        private readonly RedisCollection<BikeCart> _bikeCart;
        private readonly RedisConnectionProvider _provider;
        public CachingService(RedisConnectionProvider provider)
        {
            _provider = provider;
            _bikeCart = (RedisCollection<BikeCart>)provider.RedisCollection<BikeCart>();
        }

        public async Task AddBikeIntoCart(BikeCartDto bikeCartDto)
        {
            var bikeAlsoExistsInCart = await _bikeCart.FindByIdAsync(bikeCartDto.BikeId.ToString());

            if (bikeAlsoExistsInCart != null)
            {
                bikeAlsoExistsInCart.Amount += bikeCartDto.Amount;
                await _bikeCart.UpdateAsync(bikeAlsoExistsInCart);

            } else
            {
                var newBikeCart = new BikeCart {
                    Id = bikeCartDto.BikeId,
                    Title =  bikeCartDto.Title,
                    Amount = bikeCartDto.Amount,
                    Price = bikeCartDto.UnitaryPrice,
                    AvaliableColors = bikeCartDto.AvaliableColors.ToArray()
                };

                await _bikeCart.InsertAsync(newBikeCart);
            }

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
