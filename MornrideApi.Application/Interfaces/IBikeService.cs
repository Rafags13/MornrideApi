using MornrideApi.Domain.Entities.Dto;

namespace MornrideApi.Application.Interfaces
{
    public interface IBikeService
    {
        public IEnumerable<HomeBikeDto> GetBikesByCategory(string collection);
    }
}
