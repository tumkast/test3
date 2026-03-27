namespace WebApplication1.Services
{
    public class WeatherLabService : IWeatherLabService
    {
        private readonly IWeatherForecastService _forecasts;

        public WeatherLabService(IWeatherForecastService forecasts)
        {
            _forecasts = forecasts;
        }

        public int GetConfiguredSummaryCount() => _forecasts.GetSummaryLabels().Count;

        public string DescribeCelsius(int temperatureC) => temperatureC switch
        {
            < 0 => "cold",
            < 15 => "cool",
            < 25 => "mild",
            _ => "warm"
        };

        public IReadOnlyDictionary<string, int> GetQuickStats() =>
            new Dictionary<string, int>
            {
                ["summaryLabels"] = GetConfiguredSummaryCount(),
                ["defaultForecastDays"] = 5
            };
    }
}
