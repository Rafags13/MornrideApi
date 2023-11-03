using Microsoft.AspNetCore.Mvc;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.Model;

namespace MornrideApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagesController : Controller
    {
        private readonly ImgService _imageService;
        public ImagesController(ImgService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateImagesFromBike([FromBody] CreateImageDto image)
        {
            try
            {
                var success = await _imageService.UploadImage(image);

            if(success)
            {
                return Ok("Imagens adicionadas com sucesso!");
            }

                return BadRequest("Algo ocorreu de errado");
            } catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetImages()
        {
            try
            {
                var images = await _imageService.GetImages();

                if(images.Count == 0 || images == null)
                {
                    return NotFound("Nenhuma imagem foi encontrada");
                }

                return Ok(images);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
