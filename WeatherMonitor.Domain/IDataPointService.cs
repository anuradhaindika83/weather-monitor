using WeatherMonitor.Domain.Entities;

namespace WeatherMonitor.Domain
{
    public interface IDataPointService
    {
        /// <summary>
        ///  Select data points from the given station weather data
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>A list for matching records for the given tag</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="AmbiguousMatchException"></exception>
        /// <exception cref="TypeLoadException"></exception>
        List<DataPointEntity> GetDataPoint(string tag, List<WeatherDataEntity> weatherData);

        /// <summary>
        /// Get all the available tags for a given weather record
        /// </summary>
        /// <returns></returns>
        List<string> GetDataPointTags();

        /// <summary>
        /// Get all the available weather monitoring stations
        /// </summary>
        /// <returns></returns>
        List<StationEntity> GetStations();
    }
}