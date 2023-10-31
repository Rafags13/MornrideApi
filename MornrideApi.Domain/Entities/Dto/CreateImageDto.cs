using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Dto
{
    public class CreateImageDto
    {
        public string HexColor { get; set; } = string.Empty;
        public string FullBike { get; set; } = string.Empty;
        public string FrontBike { get; set; } = string.Empty;
        public string FrontWheel { get; set; } = string.Empty;
        public string BackWheel { get; set; } = string.Empty;
        public int BikeId { get; set; }
    }
}
