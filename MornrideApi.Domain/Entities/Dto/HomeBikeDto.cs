using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Dto
{
    public class HomeBikeDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Stock { get; set; }
        public IEnumerable<string>? AvaliableColors { get; set; }
        public IEnumerable<string>? CategoryNames { get; set; }
        public float Price { get; set; }
    }
}
