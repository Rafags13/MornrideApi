using Microsoft.AspNetCore.Mvc;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;

namespace MornrideApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BikeImageController : Controller
    {
        private readonly IBikeImageService _bikeImageService;
        public BikeImageController(IBikeImageService bikeImageService)
        {
            _bikeImageService = bikeImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                var allImagesFromBike = await _bikeImageService.GetAll();

                if (allImagesFromBike == null || allImagesFromBike.Count == 0)
                {
                    return Ok("Não existe nenhuma imagem vinculada à bike ainda. Tente inserir uma para visualizá-la.");
                }

                return Ok(allImagesFromBike);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBikeImage([FromBody] CreateBikeImageDto bikeImageDto)
        {
            try
            {
                var sucessfull = await _bikeImageService.CreateBikeImage(bikeImageDto);

                if(!sucessfull)
                {
                    return BadRequest("Não foi possível vincular a imagem à bike. Tente novamente, mais tarde");
                }

                return Ok("Vículo criado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
