using BreweryManagementAPI.Application.Services;
using BreweryManagementAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BreweryManagementAPI.Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly WholesalerService _wholesalerService;

    public OrderController(WholesalerService wholesalerService)
    {
       _wholesalerService = wholesalerService;
    }

    [HttpPost("request-quote")]
    public async Task<ActionResult> RequestQuote(Order order)
    {
        try {
            var response = await _wholesalerService.GetOrderQuoteAsync(order);
            return Ok(response);
        } catch(Exception e) {
            return BadRequest(e.Message);
        }
    }
}
