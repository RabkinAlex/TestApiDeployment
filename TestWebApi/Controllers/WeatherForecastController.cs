using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger = logger;

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public WeatherForecast Post(int temp)
        {
            var desc = temp switch
            {
                < -20 => "Freezing",
                > -20 and <= -10 => "Bracing",
                > -10 and <= 0 => "Chilly",
                > 0 and <= 10 => "Cool",
                > 10 and <= 15 => "Mild",
                > 15 and <= 20 => "Warm",
                > 20 and <= 25 => "Balmy",
                > 25 and <= 30 => "Hot",
                > 30 and <= 35 => "Sweltering",
                _ => "Scorching"
            };

            return new WeatherForecast()
            {
                Date= DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = temp,
                Summary = desc
            };
        }
    }
}
