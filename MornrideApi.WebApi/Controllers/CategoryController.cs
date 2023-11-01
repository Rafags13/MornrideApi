using Microsoft.AspNetCore.Mvc;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Model;

namespace MornrideApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("");
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok("");
        }

        [HttpPost]
        public IActionResult AddCategory([FromRoute] Category category)
        {
            return Ok("");
        }

    }
}
