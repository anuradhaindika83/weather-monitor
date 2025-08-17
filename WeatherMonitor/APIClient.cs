using Microsoft.Extensions.Configuration;
using System.Text.Json;
using WeatherMonitor.Models;

namespace WeatherMonitor
{
    public class APIClient : IAPIClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        public APIClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        public async Task<WeatherDataResponse?> GetWeather(string wmo)
        {
            try
            {

                string endpointBase = _configuration["Weather.Data.EndPoint"] ??
                    throw new ArgumentNullException("Weather.Data.EndPoint is not defined in the configuration");

                string endpoint = $"{endpointBase.TrimEnd('/').TrimEnd('\\')}/api/v1/get-weather/{wmo}";
                var rawResponse = await _client.GetAsync(endpoint);
                if (rawResponse != null && rawResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string body = await rawResponse.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<WeatherDataResponse>(body,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ??
                        throw new InvalidDataException("Invalid response");
                    return data;
                }
                else
                {
                    var resp = rawResponse ?? throw new NullReferenceException("Null response received");
                    string error = await resp.Content.ReadAsStringAsync();
                    throw new InvalidDataException(error);
                }



            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Error on GetWeather: {ex.Message}");

            }

            return default;
        }

        public async Task<List<Station>?> GetStations()
        {
            try
            {
                string endpointBase = _configuration["Weather.Data.EndPoint"] ??
                    throw new ArgumentNullException("Weather.Data.EndPoint is not defined in the configuration");

                string endpoint = $"{endpointBase.TrimEnd('/').TrimEnd('\\')}/api/v1/get-stations/";
                var rawResponse = await _client.GetAsync(endpoint);
                if (rawResponse != null && rawResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string body = await rawResponse.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<List<Station>>(body,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ??
                        throw new InvalidDataException("Invalid response");
                    return data;
                }
                else
                {
                    var resp = rawResponse ?? throw new NullReferenceException("Null response received");
                    string error = await resp.Content.ReadAsStringAsync();
                    throw new InvalidDataException(error);
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Error on GetStations: {ex.Message}" );
            }

            return default;
        }

        public async Task<List<string>?> GetAllDataPoints()
        {
            try
            {

                string endpointBase = _configuration["Weather.Data.EndPoint"] ??
                    throw new ArgumentNullException("Weather.Data.EndPoint is not defined in the configuration");

                string endpoint = $"{endpointBase.TrimEnd('/').TrimEnd('\\')}/api/v1/get-data-point-tags/";
                // _client.BaseAddress = new Uri(endpointBase);
                var rawResponse = await _client.GetAsync(endpoint);
                if (rawResponse != null && rawResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string body = await rawResponse.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<List<string>>(body,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ??
                        throw new InvalidDataException("Invalid response");
                    return data;
                }
                else
                {
                    var resp = rawResponse ?? throw new NullReferenceException("Null response received");
                    string error = await resp.Content.ReadAsStringAsync();
                    throw new InvalidDataException(error);
                }



            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Error on GetAllDataPoints: {ex.Message}");

            }

            return default;
        }

        public async Task<WeatherDataPointResponse?> GetWeatherDataForDataPoint(string tag, string wmoid)
        {
            try
            {
                string endpointBase = _configuration["Weather.Data.EndPoint"] ??
                    throw new ArgumentNullException("Weather.Data.EndPoint is not defined in the configuration");

                string endpoint = $"{endpointBase.TrimEnd('/').TrimEnd('\\')}/api/v1/get-data-point/{wmoid}/{tag}";
                var rawResponse = await _client.GetAsync(endpoint);
                if (rawResponse != null && rawResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string body = await rawResponse.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<WeatherDataPointResponse>(body,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ??
                        throw new InvalidDataException("Invalid response");
                    return data;
                }
                else
                {
                    var resp = rawResponse ?? throw new NullReferenceException("Null response received");
                    string error = await resp.Content.ReadAsStringAsync();
                    throw new InvalidDataException(error);
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Error on GetStations: {ex.Message}");
            }

            return default;
        }
    }
}
