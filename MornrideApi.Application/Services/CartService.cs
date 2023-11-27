using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.Enums;
using MornrideApi.Domain.Entities.Model;
using MornrideApi.Domain.Entities.RedisModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public async Task<bool> AddItem(AddBikeDto bikeDto)
        {
            var bikeAlsoExistsInCart = _unitOfWork.GetRepository<Cart>().GetFirstOrDefault(predicate: cart => cart.BikeId == bikeDto.BikeId);

            if(bikeAlsoExistsInCart != null)
            {
                return await UpdateCurrentAmount(bikeDto);

            }

            return await AddBikeWhenDontExistsInCart(bikeDto);
            
        }

        private async Task<bool> AddBikeWhenDontExistsInCart(AddBikeDto bikeDto)
        {
            var newBikeInCart = new Cart
            {
                BikeId = bikeDto.BikeId,
                Amount = bikeDto.Amount,
            };

            await _unitOfWork.GetRepository<Cart>().InsertAsync(newBikeInCart);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        private async Task<bool> UpdateCurrentAmount(AddBikeDto bikeDto)
        {
            var currentBikeCart = _unitOfWork.GetRepository<Cart>().GetFirstOrDefault(predicate: x => x.BikeId == bikeDto.BikeId);
            currentBikeCart.Amount += bikeDto.Amount;

            _unitOfWork.GetRepository<Cart>().Update(currentBikeCart);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<BikeCart?>> GetAllCartItems()
        {
            var bikesInCartsCache = await _cachingService.GetAllItems();

            if(bikesInCartsCache == null || !(bikesInCartsCache.Any()))
            {
                var count = _unitOfWork.GetRepository<Cart>().Count();
                var bikesInCart =
                    _unitOfWork.GetRepository<Cart>()
                    .GetPagedList(
                        pageSize: count,
                        include: x => x.Include(x => x.CurrentBike)
                        )
                    .Items
                    .Select(item => new BikeCart
                    {
                        Id = item?.CurrentBike?.Id ?? 0,
                        Amount = item?.Amount ?? 0,
                        Price = item?.CurrentBike?.Price ?? 0.0f,
                        Title = item?.CurrentBike?.Title ?? "",
                        AvaliableColors = item?.CurrentBike?.AvaliableColors?.ToArray() ?? Array.Empty<string>()
                    });

                await _cachingService.AddCurrentBikesIntoCart(bikesInCart);

                return bikesInCart;
            }

            return bikesInCartsCache;
        }

        public BikeCart GetBikeInCartByHisId(int id)
        {
            var currentBikeInCache = _unitOfWork.GetRepository<Cart>().GetFirstOrDefault(
                predicate: x => x.BikeId == id,
                include: x => x.Include(x => x.CurrentBike).ThenInclude(bikeImage => bikeImage.BikeImages).ThenInclude(images => images.Image)
                );

            if (currentBikeInCache == null)
            {
                throw new Exception("Essa bike não existe no carrinho.");
            }

            var bikeDto = new BikeCart
            {
                Id = id,
                Title = currentBikeInCache?.CurrentBike?.Title ?? "",
                Amount = currentBikeInCache?.Amount ?? 0,
                Price = currentBikeInCache?.CurrentBike?.Price ?? 0,
                AvaliableColors = currentBikeInCache?.CurrentBike?.AvaliableColors?.ToArray() ?? Array.Empty<string>(),
                ImageUrl =
                    currentBikeInCache?.CurrentBike?.BikeImages?
                        .FirstOrDefault(predicate: x => x.ImagePosition == PositionOfBikeImage.FullBike)?.Image?.Url ?? "",
            };

            return bikeDto;
        }

        public IEnumerable<BikeCart> GetBikesByIds(int[] id)
        {
            var bikes = _unitOfWork.GetRepository<Cart>()
                .GetPagedList(
                    predicate: x => id.Contains(x.BikeId),
                    include: x => x.Include(bike => bike.CurrentBike).ThenInclude(images => images.BikeImages).ThenInclude(bikeImages => bikeImages.Image)
                    )
                    .Items
                    .Select(x => new BikeCart
                    {
                        Id = x.BikeId,
                        Title = x.CurrentBike?.Title ?? "",
                        Amount = x.Amount,
                         AvaliableColors = x.CurrentBike?.AvaliableColors.ToArray() ?? Array.Empty<string>(),
                        Price = x.CurrentBike.Price,
                        ImageUrl = x.CurrentBike.BikeImages?.FirstOrDefault(predicate: x => x.ImagePosition == PositionOfBikeImage.FullBike)?.Image?.Url ?? ""
                    });

            if (!bikes.Any())
            {
                throw new Exception("Não foi possível carregar as bikes solicitadas.");
            }

            return bikes;
        }
    }
}
