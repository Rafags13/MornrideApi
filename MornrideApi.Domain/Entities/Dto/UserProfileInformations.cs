namespace MornrideApi.Domain.Entities.Dto
{
    public class UserProfileInformations
    {
        public string Name { get; set; } = string.Empty;
        public string YearsFromContribute { get; set; } = string.Empty;
        public bool IsPremiumMember { get; set; } = true;
        public IEnumerable<HomeBikeDto> LastSeenBikes { get; set; } = Enumerable.Empty<HomeBikeDto>();
        public BikeCartDto LastPurchaseBike { get; set; } = new BikeCartDto();
    }
}
