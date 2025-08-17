using WeatherMonitor.Infrastructure.Exceptions;

namespace WeatherMonitor.Infrastructure
{
    public interface IBOMApiClient
    {
        /// <summary>
        /// Send a request to the given weather station
        /// </summary>
        /// <param name="request">Conatins the weather station id that needs be sent to</param>
        /// <returns>An object containing the wether station data</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="BadBOMResponseDataException"></exception>
        Task<BOMResponse?> GetStationDataAsync(BOMRequest request);
    }
}
