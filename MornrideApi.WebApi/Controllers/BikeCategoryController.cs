using Microsoft.AspNetCore.Mvc;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBikeCategoryDto createBikeCategoryDto)
        {
            try
            {
                var sucessful = await _bikeCategoryService.CreateLinkForBike(createBikeCategoryDto);

                if(!sucessful)
                {
                    return BadRequest("Não foi possível criar o vínculo entre categoria e bike. Tente novamente, mais tarde");
                }

                return Ok("Vínculo criado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
