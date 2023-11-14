using Microsoft.AspNetCore.Mvc;

namespace MornrideApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult GetHomeInformations()
        {
            return Ok("");
        }
    }
}
