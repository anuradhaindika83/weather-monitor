using WeatherMonitor.Domain.Entities;

namespace WeatherMonitor.Domain
{
    public interface IDomainService
    {
        /// <summary>
        /// Calculates the average temperature of the given station for the past 72 hours
        /// </summary>
        /// <param name="weatherData"></param>
        /// <returns>The average temperature</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        double GetAverageTemperature(List<WeatherDataEntity> weatherData);
    }
}