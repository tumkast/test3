namespace WebApplication1.Services
{
    public interface IWeatherLabService
    {
        int GetConfiguredSummaryCount();

        string DescribeCelsius(int temperatureC);

        IReadOnlyDictionary<string, int> GetQuickStats();
    }
}
