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
        public CartController(ICachingService cachingService)
        {
            _cachingService = cachingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var bikes = await _cachingService.GetAllItems();

            if (!bikes.Any())
            {
                return Ok("Nenhuma bike existe no carrinho.");
            }
            return Ok(bikes);
        }

        [HttpPost]
        public async Task<IActionResult> AddBikeIntoCart([FromBody] BikeCart bikeCart)
        {
            await _cachingService.AddBikeIntoCart(bikeCart);

            return Ok($"Bike: {bikeCart.Title} adicionada ao carrinho!");
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
