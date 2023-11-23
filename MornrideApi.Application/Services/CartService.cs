using Arch.EntityFrameworkCore.UnitOfWork;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.Model;
using MornrideApi.Domain.Entities.RedisModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICachingService _cachingService;
        public CartService(IUnitOfWork unitOfWork, ICachingService cachingService)
        {
            _unitOfWork = unitOfWork;
            _cachingService = cachingService;
        }

        public async Task<bool> AddItem(BikeCartDto bikeCartDto)
        {
            await _cachingService.AddBikeIntoCart(bikeCartDto);

            var bikeAlsoExistsInCart = _unitOfWork.GetRepository<Cart>().GetFirstOrDefault(predicate: cart => cart.BikeId == bikeCartDto.BikeId);

            if(bikeAlsoExistsInCart == null)
            {
                return await AddBikeWhenDontExistsInCart(bikeCartDto.BikeId, bikeCartDto.Amount);
            }

            return await UpdateCurrentAmount(bikeCartDto.BikeId, bikeCartDto.Amount);
        }

        private async Task<bool> AddBikeWhenDontExistsInCart(int bikeId, int amount)
        {
            var newBikeInCart = new Cart
            {
                BikeId = bikeId,
                Amount = amount,
            };

            await _unitOfWork.GetRepository<Cart>().InsertAsync(newBikeInCart);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        private async Task<bool> UpdateCurrentAmount(int bikeId, int amount)
        {
            var currentBikeCart = _unitOfWork.GetRepository<Cart>().GetFirstOrDefault(predicate: x => x.BikeId == bikeId);
            currentBikeCart.Amount += amount;

            _unitOfWork.GetRepository<Cart>().Update(currentBikeCart);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<BikeCartDto>> GetAllCartItems()
        {
            throw new NotImplementedException();
        }
    }
}
