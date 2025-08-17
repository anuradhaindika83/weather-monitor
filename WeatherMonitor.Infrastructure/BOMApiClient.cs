using Microsoft.Extensions.Options;
using System.Net;
using System.Text.Json;
using WeatherMonitor.Infrastructure.Exceptions;

namespace WeatherMonitor.Infrastructure
{
    public class BOMApiClient : IBOMApiClient
    {
        private readonly HttpClient _client;
        private readonly BOMOptions _options;

        /// <summary>
        /// Initializes a new instance of BOMApiClient with the specified base url and the productid
        /// </summary>
        /// <param name="client">An instance of HttpClient</param>
        /// <param name="options">An instance of BOMOptions including the base url and the product id</param>
        public BOMApiClient(HttpClient client, IOptionsSnapshot<BOMOptions> options)
        {
            _client = client;
            _options = options.Value;
        }

        /// <summary>
        /// Send a request to the given weather station
        /// </summary>
        /// <param name="request">Conatins the weather station id that needs be sent to</param>
        /// <returns>An object containing the wether station data</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="BadBOMResponseDataException"></exception>
        public async Task<BOMResponse?> GetStationDataAsync(BOMRequest request)
        {
            if (string.IsNullOrEmpty(_options.Url)) throw new ArgumentNullException(nameof(_options.Url));

            string endPoint = $"{_options.Url.TrimEnd('/')}/fwo/{_options.ProductID}/{_options.ProductID}.{request.WeatherObservationStationId}.json";

            //These headers are added to mimic browser behavior and may temporarily bypass BOM's automated access restrictions.
            //This approach is not compliant with BOM's terms and must not be used in production!

            _client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/139.0.0.0 Safari/537.36 Edg/139.0.0.0");
            _client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            _client.DefaultRequestHeaders.Referrer = new Uri(_options.Url);

            HttpResponseMessage rawResponse = await _client.GetAsync(endPoint);
            if (rawResponse != null && rawResponse.StatusCode == HttpStatusCode.OK)
            {
                string body = await rawResponse.Content.ReadAsStringAsync();
                BOMResponse response = JsonSerializer.Deserialize<BOMResponse>(body) ?? throw new BadBOMResponseDataException(nameof(body));
                return response;
            }

            if (rawResponse != null)
            {
                string content = await rawResponse.Content.ReadAsStringAsync();
                throw new BOMRequestFailedException(rawResponse.StatusCode, content, endPoint);
            }

            throw new BOMGenericErrorException(nameof(HttpResponseMessage), "Null reference received for the response");


        }
    }
}
