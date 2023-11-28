using System.Collections.ObjectModel;

namespace MornrideApi.Domain.Entities.Dto
{
    public class BikeImagesByColorDto
    {
        public string HexColor { get; set; } = string.Empty;
        public IEnumerable<BikeImagesProfileDto> BikeImages { get; set; } = Enumerable.Empty<BikeImagesProfileDto>();
    }
}
