using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

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

        [HttpGet("summaries")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<string>> GetSummaries()
        {
            return Ok(Summaries);
        }

        [HttpGet("random-summary")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public ActionResult<string> GetRandomSummary()
        {
            return Ok(Summaries[Random.Shared.Next(Summaries.Length)]);
        }

        [HttpGet("today")]
        [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status200OK)]
        public ActionResult<WeatherForecast> GetToday()
        {
            return Ok(new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Today),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });
        }

        [HttpGet("forecast-for/{daysOffset:int}")]
        [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status200OK)]
        public ActionResult<WeatherForecast> GetForecastFor(int daysOffset)
        {
            return Ok(new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Today.AddDays(daysOffset)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });
        }
    }
}
