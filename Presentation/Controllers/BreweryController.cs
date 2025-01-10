using Microsoft.AspNetCore.Mvc;
using BreweryManagementAPI.Application.Services;
using System.Collections.Generic;
using BreweryManagementAPI.Domain.Entities;

namespace BreweryManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreweryController : ControllerBase
    {
        private readonly BreweryService _breweryService;

        public BreweryController(BreweryService breweryService)
        {
            _breweryService = breweryService;
        }

        [HttpGet("all-beers-by-brewery")]
        public async Task<ActionResult<List<Brewery>>> GetAllBeersByBrewery()
        {
            var breweries = await _breweryService.GetBreweriesWithBeersAsync();
            
            return Ok(breweries);
        }
    }
}
