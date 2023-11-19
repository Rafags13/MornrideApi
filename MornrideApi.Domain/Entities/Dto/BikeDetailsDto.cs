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
        public BikeImagesProfileDto Images { get; set; } = new BikeImagesProfileDto();
        public string Title { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<string> Categories { get; set; } = new Collection<string>(); 
    }
}
