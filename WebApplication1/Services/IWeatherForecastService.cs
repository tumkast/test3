namespace WebApplication1.Services
{
    public interface IWeatherForecastService
    {
        WeatherForecast GetForecastForDate(DateOnly date);

        IReadOnlyList<string> GetSummaryLabels();

        string GetRandomSummaryLabel();
    }
}
