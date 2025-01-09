using Microsoft.AspNetCore.Mvc;
using BreweryManagementAPI.Application.Services;
using System.Collections.Generic;
using BreweryManagementAPI.Domain.Entities;

namespace BreweryManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrewerController : ControllerBase
    {
        private readonly BreweryService _breweryService;

        public BrewerController(BreweryService breweryService)
        {
            _breweryService = breweryService;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello World From BrewerController";
        }
    }
}
