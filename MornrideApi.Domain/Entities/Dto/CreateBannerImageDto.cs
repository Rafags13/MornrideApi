using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Dto
{
    public class CreateBannerImageDto
    {
        public string Label { get; set; } = string.Empty;
        public string Collection { get; set; } = string.Empty;
        public int ImageBannerId { get; set; }
    }
}
