using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MornrideApi.Application.Interfaces;
using MornrideApi.Domain.Entities.Dto;
using MornrideApi.Domain.Entities.Model;

namespace MornrideApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BikeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBikeService _bikeService;
        public BikeController(IUnitOfWork unitOfWork, IBikeService bikeService) 
        {
            _unitOfWork = unitOfWork;
            _bikeService = bikeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var bikes = _bikeService.GetAll();
                return Ok(bikes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBikeDto bikeDto) 
        {
            try
            {
                var success = await _bikeService.AddBike(bikeDto);

                if (!success)
                {
                    return BadRequest("Não foi possível adicionar a bike. Tente novamente, mais tarde.");
                }

                return Ok("Bike adicionada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{collection}")]
        public IActionResult GetBikesByCollection([FromRoute] string collection)
        {
            try
            {
                var bikes = _bikeService.GetBikesByCategory(collection);
                return Ok(bikes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
