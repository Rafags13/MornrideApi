using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Dto
{
    public class CreateLinkBikeCategoryDto
    {
        public int BikeId { get; set; }
        public int CategoryId { get; set; }
    }
}
