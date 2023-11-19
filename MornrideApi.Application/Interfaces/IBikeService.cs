using MornrideApi.Domain.Entities.Dto;

namespace MornrideApi.Application.Interfaces
{
    public interface IBikeService
    {
        public IEnumerable<HomeBikeDto> GetBikesByCategory(string collection);
        public IEnumerable<HomeBikeDto> GetAll();
        public Task<bool> AddBike(CreateBikeDto bikeDto);
        public BikeDetailsDto GetBikeDetails(int bikeId);
    }
}
