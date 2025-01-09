using BreweryManagementAPI.Application.Services;
using BreweryManagementAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BreweryManagementAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeerController : ControllerBase
    {
        private readonly BeerService _beerService;

        public BeerController(BeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var beers = await _beerService.GetAllBeersAsync();
            return Ok(beers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var beer = await _beerService.GetBeerByIdAsync(id);
            if (beer == null) return NotFound();
            return Ok(beer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Beer beer)
        {
            await _beerService.AddBeerAsync(beer);
            return CreatedAtAction(nameof(Get), new { id = beer.Id }, beer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Beer beer)
        {
            if (id != beer.Id) return BadRequest();
            await _beerService.UpdateBeerAsync(beer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _beerService.DeleteBeerAsync(id);
            return NoContent();
        }
    }
}
