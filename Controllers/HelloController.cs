
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    IHello helloServices;

    public HelloController(IHello helloS){
        helloServices = helloS;
    }

    public IActionResult Get(){
        return Ok(helloServices.GetHello());
    }
    
}