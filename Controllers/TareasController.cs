using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

public class TareasController : ControllerBase
{
    ITareaService tareaservice;

    public TareasController(ITareaService service)
    {
        tareaservice = service;
    }


    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareaservice.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        tareaservice.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] Tarea tarea)
    {
        tareaservice.Update(id, tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        tareaservice.Delete(id);
        return Ok();
    }





}