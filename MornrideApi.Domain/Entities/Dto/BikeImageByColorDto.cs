using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Dto
{
    public class BikeImageByColorDto
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string HexColor { get; set; } = string.Empty;
    }
}
