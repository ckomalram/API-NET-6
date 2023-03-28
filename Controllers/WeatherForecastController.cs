using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();


    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if (ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
            //.ToArray();

        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    // para indicarle alcontrolador las diferentes rutas por la que se puede ingresar al endpoint get.
    // [Route("get/weatherforecast")]
    // [Route("get/weatherforecast2")]
    // get es el nombre c como tal del metodo.
    // [Route([action])]
    public IEnumerable<WeatherForecast> Get()
    {
        // _logger.LogInformation("API returning list weather forecaste");
        _logger.LogDebug("API returning list weather forecaste");
        return ListWeatherForecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherforecast)
    {
        ListWeatherForecast.Add(weatherforecast);

        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index){

        ListWeatherForecast.RemoveAt(index);
        return Ok();
    }
}
