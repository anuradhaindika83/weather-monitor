using WeatherMonitor.Models;

namespace WeatherMonitor
{
    public interface IAPIClient
    {
        Task<WeatherDataResponse?> GetWeather(string wmo);
        Task<List<Station>?> GetStations();
        Task<List<string>?> GetAllDataPoints();
        Task<WeatherDataPointResponse?> GetWeatherDataForDataPoint(string tag, string wmoid);
    }
}
