using Microsoft.AspNetCore.Mvc;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;

namespace MornrideApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BannerImageController: Controller
    {
        private readonly IBannerImageService _bannerImageService;
        public BannerImageController(IBannerImageService bannerImageService)
        {
            _bannerImageService = bannerImageService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBannerImageDto createBannerImageDto)
        {
            try
            {
                var success = await _bannerImageService.CreateImage(createBannerImageDto);

                if (!success)
                {
                    return BadRequest("Não foi possível criar o vínculo do banner com a imagem. Tente novamente mais tarde.");
                }

                return Ok("Vínculo criado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
               var allBikeImages = await _bannerImageService.GetAll();

               if(!(allBikeImages.Any()) || allBikeImages == null) {
                    return Ok("Nenhum banner está cadastrado no sistema, atualmente. Tente cadastrar um e faça essa chamada novamente.");
                }

                return Ok(allBikeImages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
