using Microsoft.AspNetCore.Mvc;

namespace MornrideApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BikeImageController : Controller
    {
        public BikeImageController() { }

        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok("");
        }
    }
}
