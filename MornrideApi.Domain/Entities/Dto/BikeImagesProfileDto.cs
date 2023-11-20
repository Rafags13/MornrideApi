using MornrideApi.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Dto
{
    public class BikeImagesProfileDto
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
    }
}
