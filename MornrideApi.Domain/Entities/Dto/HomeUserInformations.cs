using MornrideApi.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Dto
{
    public class HomeUserInformations
    {
        public HomeUserInformations(ICollection<HomeBannerDto> banners, ICollection<HomeCategoryDto> categories, ICollection<HomeBikeDto> bikes)
        {
            Banners = banners;
            Categories = categories;
            Bikes = bikes;
        }

        public HomeUserInformations() { }

        public IEnumerable<HomeBannerDto> Banners { get; set; } = Enumerable.Empty<HomeBannerDto>();
        public IEnumerable<HomeCategoryDto> Categories { get; set; } = Enumerable.Empty<HomeCategoryDto>();
        public IEnumerable<HomeBikeDto> Bikes { get; set; } = Enumerable.Empty<HomeBikeDto>();
    }
}
