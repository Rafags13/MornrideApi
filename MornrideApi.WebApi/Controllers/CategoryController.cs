using Microsoft.AspNetCore.Mvc;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;
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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _categoryService.GetAll();

                if(categories == null || categories.Count() == 0)
                {
                    return Ok("Não existe nenhuma categoria cadastrada atualmente no sistema.");
                }

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var category = _categoryService.GetById(id);

                if(category == null)
                {
                    return NotFound("Não existe nenhuma categoria no índice buscado. Tente novamente mais tarde.");
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryDto category)
        {
            try
            {
                var sucess = await _categoryService.AddCategory(category);

                if(!sucess)
                {
                    return BadRequest("Não foi possível inserir a categoria. Tente Novamente mais tarde.");
                }

                return Ok("Categoria adicionada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
