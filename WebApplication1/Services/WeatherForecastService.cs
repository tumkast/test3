namespace WebApplication1.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecast GetForecastForDate(DateOnly date)
        {
            return new WeatherForecast
            {
                Date = date,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }

        public IReadOnlyList<string> GetSummaryLabels() => Summaries;

        public string GetRandomSummaryLabel() =>
            Summaries[Random.Shared.Next(Summaries.Length)];

        public IReadOnlyList<WeatherForecast> GetForecastsForNextDays(int count)
        {
            return Enumerable.Range(1, count)
                .Select(i => GetForecastForDate(DateOnly.FromDateTime(DateTime.Now.AddDays(i))))
                .ToArray();
        }
    }
}
