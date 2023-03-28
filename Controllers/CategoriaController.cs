using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;


[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    ICategoriaService categoriaservice;

    public CategoriaController(ICategoriaService service)
    {
        categoriaservice = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoriaservice.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        categoriaservice.Save(categoria);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] Categoria categoria)
    {
        categoriaservice.Update(id, categoria);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoriaservice.Delete(id);
        return Ok();
    }




}