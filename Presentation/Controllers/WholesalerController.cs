using BreweryManagementAPI.Application.Services;
using BreweryManagementAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BreweryManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WholesalerController : ControllerBase
    {
        private readonly WholesalerService _wholesalerService;

        public WholesalerController(WholesalerService wholesalerService)
        {
            _wholesalerService = wholesalerService;
        }

        [HttpPost("wholesaler-stock-action")]
        public async Task<IActionResult> CreateStockAction([FromBody] WholesalerStock stockAction)
        {
            await _wholesalerService.AddWholesalerStockAtionAsync(stockAction);
            return CreatedAtAction(nameof(CreateStockAction), new { id = stockAction.Id }, stockAction);
        }
    }
}
