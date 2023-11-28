using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Dto
{
    public class CreateBikeImageDto
    {
        public string HexColor { get; set; } = string.Empty;
        public string ImagePosition { get; set; } = string.Empty;
        public int ImageId { get; set; }
        public int BikeId { get; set; }
    }
}
