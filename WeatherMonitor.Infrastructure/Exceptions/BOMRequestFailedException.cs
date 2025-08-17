using System.Net;

namespace WeatherMonitor.Infrastructure.Exceptions
{
    public class BOMRequestFailedException: Exception
    {
        public BOMRequestFailedException(HttpStatusCode statusCode, string message, string endPoint) 
            : base($"Request for the {endPoint} failed with {(int)statusCode}.{message}") { }
    }
}
