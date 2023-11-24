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
        private readonly IBikeService _bikeService;
        public BikeController(IBikeService bikeService) 
        {
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

        [HttpGet("Profile/{bikeId}")]
        public IActionResult GetBikeDetail([FromRoute] int bikeId)
        {
            try
            {
                var bikeProfile = _bikeService.GetBikeDetails(bikeId);

                return Ok(bikeProfile);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Names")]
        public IActionResult GetBikeNames()
        {
            try
            {
                var bikeNames = _bikeService.GetAvaliableBikeNames();

                return Ok(bikeNames);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("ByName/{title}")]
        public IActionResult GetByName(string title)
        {
            try
            {
                var bikesByName = _bikeService.GetBikesByName(title);

                return Ok(bikesByName);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
