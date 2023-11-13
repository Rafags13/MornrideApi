using Microsoft.AspNetCore.Mvc;
using MornrideApi.Domain.Entities.Dto;

namespace MornrideApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BannerImageController: Controller
    {
        [HttpPost]
        public IActionResult Create([FromBody] CreateBannerImageDto createBannerImageDto)
        {
            return Ok("");
        }
    }
}
