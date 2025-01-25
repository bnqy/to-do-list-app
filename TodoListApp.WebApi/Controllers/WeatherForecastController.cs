using Microsoft.AspNetCore.Mvc;

namespace TodoListApp.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
    };

#pragma warning disable SA1309 // Field names should not begin with underscore
#pragma warning disable IDE0052 // Remove unread private members
#pragma warning disable S4487 // Unread "private" fields should be removed
    private readonly ILogger<WeatherForecastController> _logger;
#pragma warning restore S4487 // Unread "private" fields should be removed
#pragma warning restore IDE0052 // Remove unread private members
#pragma warning restore SA1309 // Field names should not begin with underscore

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        this._logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
#pragma warning disable CA5394 // Do not use insecure randomness
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
        })
        .ToArray();
#pragma warning restore CA5394 // Do not use insecure randomness
    }
}
