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
        private readonly IWeatherLabService _labService;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IWeatherForecastService forecastService,
            IWeatherLabService labService)
        {
            _logger = logger;
            _forecastService = forecastService;
            _labService = labService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rows = _forecastService.GetForecastsForNextDays(5);
            _logger.LogDebug("Returning {Count} default forecast rows", rows.Count);
            return rows;
        }

        [HttpGet("summaries")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<string>> GetSummaries()
        {
            return Ok(_forecastService.GetSummaryLabels());
        }

        [HttpGet("today")]
        [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status200OK)]
        public ActionResult<WeatherForecast> GetToday()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var forecast = _forecastService.GetForecastForDate(today);
            _logger.LogInformation(
                "Serving today forecast for {Date}: {TempC}°C, {Summary}",
                forecast.Date,
                forecast.TemperatureC,
                forecast.Summary);
            return Ok(forecast);
        }

        [HttpGet("forecast-for/{daysOffset:int}")]
        [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status200OK)]
        public ActionResult<WeatherForecast> GetForecastFor(int daysOffset)
        {
            return Ok(_forecastService.GetForecastForDate(
                DateOnly.FromDateTime(DateTime.Today.AddDays(daysOffset))));
        }

        [HttpGet("lab/summary-count")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public ActionResult<int> GetLabSummaryCount()
        {
            return Ok(_labService.GetConfiguredSummaryCount());
        }

        [HttpGet("lab/temperature-band")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public ActionResult<string> GetLabTemperatureBand([FromQuery] int celsius)
        {
            return Ok(_labService.DescribeCelsius(celsius));
        }

        [HttpGet("lab/stats")]
        [ProducesResponseType(typeof(IReadOnlyDictionary<string, int>), StatusCodes.Status200OK)]
        public ActionResult<IReadOnlyDictionary<string, int>> GetLabStats()
        {
            return Ok(_labService.GetQuickStats());
        }
    }
}
