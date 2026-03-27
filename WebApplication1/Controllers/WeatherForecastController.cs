using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _forecastService;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IWeatherForecastService forecastService)
        {
            _logger = logger;
            _forecastService = forecastService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _forecastService.GetForecastsForNextDays(5);
        }

        [HttpGet("summaries")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<string>> GetSummaries()
        {
            return Ok(_forecastService.GetSummaryLabels());
        }

        [HttpGet("random-summary")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public ActionResult<string> GetRandomSummary()
        {
            return Ok(_forecastService.GetRandomSummaryLabel());
        }

        [HttpGet("today")]
        [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status200OK)]
        public ActionResult<WeatherForecast> GetToday()
        {
            return Ok(_forecastService.GetForecastForDate(DateOnly.FromDateTime(DateTime.Today)));
        }

        [HttpGet("forecast-for/{daysOffset:int}")]
        [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status200OK)]
        public ActionResult<WeatherForecast> GetForecastFor(int daysOffset)
        {
            return Ok(_forecastService.GetForecastForDate(
                DateOnly.FromDateTime(DateTime.Today.AddDays(daysOffset))));
        }
    }
}
