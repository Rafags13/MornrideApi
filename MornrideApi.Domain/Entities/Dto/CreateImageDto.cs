using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Dto
{
    public class CreateImageDto
    {
        public string Url { get; set; } = string.Empty;

        public string Description {  get; set; } = string.Empty;
    }
}
