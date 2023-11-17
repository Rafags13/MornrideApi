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
        public BikeController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allBikes = _unitOfWork.GetRepository<Bike>().GetPagedList(include: x => x.Include(x => x.BikeCategories).ThenInclude(bikeCategory => bikeCategory.Category));
            return Ok(allBikes.Items);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBikeDto bikeDto) 
        {
            var newBike = new Bike { Title = bikeDto.Title, Description = bikeDto.Description, Price = bikeDto.Price, Stock = bikeDto.Stock };
            _unitOfWork.GetRepository<Bike>().Insert(newBike);

            await _unitOfWork.SaveChangesAsync();

            return Ok("Bike adicionada com sucesso");
            
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
