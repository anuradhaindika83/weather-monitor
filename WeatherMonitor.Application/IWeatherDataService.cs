using WeatherMonitor.Application.Dto;
using WeatherMonitor.Application.Exceptions;
using WeatherMonitor.Infrastructure.Exceptions;

namespace WeatherMonitor.Application
{
    public interface IWeatherDataService
    {
        /// <summary>
        ///  Get weather data for a given observation station 
        /// </summary>
        /// <param name="wmoid">Weather observation station id</param>
        /// <returns>Weather station data for the past 72 hours</returns>
        /// <exception cref="InvalidStationIdException"></exception>
        /// <exception cref="InvalidMappingException"></exception>
        Task<WeatherDataDTO> GetAllWeatherDataAsync(string wmoid);


        /// <summary>
        /// Get data for given data point. This considers all the data up to past 72 hours.
        /// </summary>
        /// <param name="wmoid"></param>
        /// <param name="tag"></param>
        /// <returns>The data for the given data point</returns>
        /// <exception cref="InvalidStationIdException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="BadBOMResponseDataException"></exception>
        Task<List<DataPointDTO>> GetWeatherDataPointAsync(string wmoid, string tag);

        /// <summary>
        /// Get all the available weather observation stations
        /// </summary>
        /// <returns>All the weather stations</returns>
        List<StationDTO> GetStations();

        /// <summary>
        /// Get all the available data point tags
        /// </summary>
        /// <returns>All the data point tags</returns>
        List<string> GetDataPointTags();
    }
}