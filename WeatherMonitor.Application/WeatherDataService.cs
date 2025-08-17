using WeatherMonitor.Application.Dto;
using WeatherMonitor.Application.Exceptions;
using WeatherMonitor.Application.Extensions;
using WeatherMonitor.Domain;
using WeatherMonitor.Domain.Entities;
using WeatherMonitor.Infrastructure;
using WeatherMonitor.Infrastructure.Exceptions;

namespace WeatherMonitor.Application
{
    public class WeatherDataService : IWeatherDataService
    {
        private readonly IBOMApiClient _bomapiClient;
        private readonly IDomainService _domainService;
        private readonly IDataPointService _dataPointService;

        public WeatherDataService(IBOMApiClient client, IDomainService domain, IDataPointService dataPoint)
        {
            _bomapiClient = client;
            _domainService = domain;
            _dataPointService = dataPoint;
        }

        /// <summary>
        ///  Get weather data for a given observation station 
        /// </summary>
        /// <param name="wmoid">Weather observation station id</param>
        /// <returns>Weather station data for the past 72 hours</returns>
        /// <exception cref="InvalidStationIdException"></exception>
        /// <exception cref="InvalidMappingException"></exception>
        public async Task<WeatherDataDTO> GetAllWeatherDataAsync(string wmoid)
        {
            if (string.IsNullOrEmpty(wmoid)) throw new InvalidStationIdException();

            BOMResponse? response = await _bomapiClient.GetStationDataAsync(new BOMRequest() { WeatherObservationStationId = wmoid });

            List<WeatherDataEntity> entities = response.MapToEntity();

            WeatherDataDTO weatherData = entities.MapToDTO();
            weatherData.AverageTemperature = _domainService.GetAverageTemperature(entities);

            return weatherData;
        }

        /// <summary>
        /// Get all the available weather observation stations
        /// </summary>
        /// <returns>All the weather stations</returns>
        public List<StationDTO> GetStations()
        {
            var entities = _dataPointService.GetStations();
            return entities.MapToStationDTO();
        }

        /// <summary>
        /// Get all the available data point tags
        /// </summary>
        /// <returns>All the data point tags</returns>
        public List<string> GetDataPointTags() => _dataPointService.GetDataPointTags();

        /// <summary>
        /// Get data for given data point. This considers all the data up to past 72 hours.
        /// </summary>
        /// <param name="wmoid"></param>
        /// <param name="tag"></param>
        /// <returns>The data for the given data point</returns>
        /// <exception cref="InvalidStationIdException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="BadBOMResponseDataException"></exception>
        public async Task<List<DataPointDTO>> GetWeatherDataPointAsync(string wmoid, string tag)
        {
            if (string.IsNullOrEmpty(wmoid)) throw new InvalidStationIdException();

            BOMResponse? response = await _bomapiClient.GetStationDataAsync(new BOMRequest() { WeatherObservationStationId = wmoid });

            List<WeatherDataEntity> entities = response.MapToEntity();
            List<DataPointEntity> points =  _dataPointService.GetDataPoint(tag, entities);
            return points.MapToDataPointDTO();


        }

    }
}
