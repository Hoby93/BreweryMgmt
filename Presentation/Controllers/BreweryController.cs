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

        [HttpGet]
        public string Get()
        {
            return "Hello World From BreweryController";
        }

        [HttpGet("all-beers-by-brewery")]
        public ActionResult<List<Brewery>> GetAllBeersByBrewery()
        {
            var breweries = _breweryService.GetAllBeersByBrewery();
            return Ok(breweries);
        }
    }
}
