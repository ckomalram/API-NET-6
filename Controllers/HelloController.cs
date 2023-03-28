
using Microsoft.AspNetCore.Mvc;
using webapi.Context;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    IHello helloServices;
    TareaContext dbcontext;

    public HelloController(IHello helloS , TareaContext context){
        helloServices = helloS;

        dbcontext = context;
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok(helloServices.GetHello());
    }

    [HttpGet]
    [Route("dbconexion")]
    public IActionResult CreateDatabase(){
        dbcontext.Database.EnsureCreated();

        return Ok();
    }
    
}