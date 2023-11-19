using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Dto
{
    public class BikeImagesProfileDto
    {
        public string FullBikeUrl { get; set; } = string.Empty;
        public string BackWheelUrl { get; set; } = string.Empty;
        public string FrontBikeUrl { get; set; } = string.Empty;
        public string FrontWheelUrl { get; set; } = string.Empty;
    }
}
