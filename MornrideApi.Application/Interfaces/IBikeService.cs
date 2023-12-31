﻿using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.RedisModels;

namespace MornrideApi.Application.Interfaces
{
    public interface IBikeService
    {
        public IEnumerable<HomeBikeDto> GetBikesByCategory(string collection);
        public IEnumerable<HomeBikeDto> GetAll();
        public Task<bool> AddBike(CreateBikeDto bikeDto);
        public BikeDetailsDto GetBikeDetails(int bikeId);
        public IEnumerable<string?> GetAvaliableBikeNames();
        public IEnumerable<HomeBikeDto?> GetBikesByName(string title);
        public BikeCart BuyNow(int bikeId, int amount);
    }
}
