using Microsoft.AspNetCore.Mvc;
using MornrideApi.Application.Interfaces;

namespace MornrideApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BikeCategoryController : Controller
    {
        private readonly IBikeCategoryService _bikeCategoryService;
        public BikeCategoryController(IBikeCategoryService bikeCategoryService)
        {
            _bikeCategoryService = bikeCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var AllBikeCategories = await _bikeCategoryService.GetAll();

                if (AllBikeCategories == null || !(AllBikeCategories.Any()))
                {
                    return Ok("Não existe nenhuma categoria vinculada à bike ainda. Tente inserir uma para visualizá-la.");
                }

                return Ok(AllBikeCategories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
