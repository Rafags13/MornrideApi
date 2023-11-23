using Microsoft.AspNetCore.Mvc;
using MornrideApi.Application.Interfaces;
using Newtonsoft.Json;
using Redis.OM.Searching;
using Redis.OM;
using System;
using MornrideApi.Domain.Entities.RedisModels;
using Microsoft.EntityFrameworkCore;

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
            //var bikes = await _cachingService.GetAllItems();
            try
            {
                var bikes = await _cartService.GetAllCartItems();

                if (!bikes.Any())
                {
                    return Ok("Nenhuma bike existe no carrinho.");
                }
                return Ok(bikes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBikeIntoCart([FromBody] int bikeId)
        {
            try
            {
                //await _cachingService.AddBikeIntoCart(bikeCart);
                var success = await _cartService.AddItem(bikeId: bikeId);
                if (!success)
                {
                    return NotFound("Não foi possível encontrar a bike solicitada no momento. Tente novamente mais tarde.");
                }

                return Ok($"Bike adicionada ao carrinho!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBikeCardById([FromRoute] string id)
        {
            var bike = await _cachingService.GetBikeCardById(id);

            if (bike is null)
            {
                return NotFound();
            }
            return Ok(bike);
        }

    }
}
