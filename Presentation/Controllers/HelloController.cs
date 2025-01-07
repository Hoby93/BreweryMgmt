using Microsoft.AspNetCore.Mvc;

namespace BreweryManagementAPI.Presentation.Controllers;


[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hello World";
    }
}
