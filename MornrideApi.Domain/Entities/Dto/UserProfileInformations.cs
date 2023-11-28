using MornrideApi.Domain.Entities.RedisModels;

namespace MornrideApi.Domain.Entities.Dto
{
    public class UserProfileInformations
    {
        public string Name { get; set; } = string.Empty;
        public byte YearsFromContribute { get; set; }
        public bool IsPremiumMember { get; set; } = true;
        public IEnumerable<HomeBikeDto> LastSeenBikes { get; set; } = Enumerable.Empty<HomeBikeDto>();
        public BikeCart LastPurchaseBike { get; set; } = new BikeCart();
    }
}
