using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Dto
{
    public class BikeDetailsDto
    {
        public IEnumerable<BikeImagesProfileDto> Images { get; set; } = Enumerable.Empty<BikeImagesProfileDto>();
        public string Title { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string> AvaliableColors { get; set; } = Enumerable.Empty<string>();
    }
}
