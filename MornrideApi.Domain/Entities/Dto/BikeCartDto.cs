using MornrideApi.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Dto
{
    public class BikeCartDto
    {
        public int BikeId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Amount { get; set; }
        public float UnitaryPrice { get; set; }
        public IEnumerable<string> AvaliableColors {  get; set; } = Enumerable.Empty<string>();
    }
}
