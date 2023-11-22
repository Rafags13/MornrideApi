using Microsoft.Extensions.Caching.Distributed;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.RedisModels;
using Redis.OM.Searching;
using Redis.OM;

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

        public async Task AddBikeIntoCart(BikeCart bikeCart)
        {
            var bikeAlsoExistsInCart = await _bikeCart.FindByIdAsync(bikeCart.Id.ToString());

            if (bikeAlsoExistsInCart != null)
            {
                bikeAlsoExistsInCart.Amount += bikeCart.Amount;
                await _bikeCart.UpdateAsync(bikeAlsoExistsInCart);
            }

            await _bikeCart.InsertAsync(bikeCart);
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
