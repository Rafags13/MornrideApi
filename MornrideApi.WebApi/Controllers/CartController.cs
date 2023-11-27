using Microsoft.AspNetCore.Mvc;
using MornrideApi.Application.Interfaces;
using Newtonsoft.Json;
using Redis.OM.Searching;
using Redis.OM;
using System;
using MornrideApi.Domain.Entities.RedisModels;
using Microsoft.EntityFrameworkCore;
using MornrideApi.Domain.Entities.Dto;

namespace MornrideApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : Controller
    {
        private readonly ICachingService _cachingService;
        private readonly ICartService _cartService;
        public CartController(ICachingService cachingService, ICartService cartService)
        {
            _cachingService = cachingService;
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            try
            {
                var bikes = await _cartService.GetAllCartItems();

                if (!bikes.Any())
                {
                    return Ok(Enumerable.Empty<BikeCart>());
                }
                return Ok(bikes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBikeIntoCart([FromBody] AddBikeDto bikeDto)
        {
            try
            {
                var success = await _cartService.AddItem(bikeDto);
                if (!success)
                {
                    return NotFound("Não foi possível encontrar a bike solicitada no momento. Tente novamente mais tarde.");
                }

                var currentBike = _cartService.GetBikeInCartByHisId(bikeDto.BikeId);

                await _cachingService.AddBikeIntoCart(currentBike);

                return Ok($"Bike adicionada ao carrinho!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("{id}")]
        public IActionResult GetBikeCardById([FromRoute] int id)
        {
            try
            {
                var bike = _cartService.GetBikeInCartByHisId(id);

                return Ok(bike);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("ByIds")]
        public IActionResult GetBikesByIds([FromQuery] int[] ids)
        {
            try
            {
                var bikes = _cartService.GetBikesByIds(ids);

                return Ok(bikes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
