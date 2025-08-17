using Microsoft.OpenApi.Any;
using WeatherMonitorWebAPI.Models;

namespace WeatherMonitorWebAPI.Utils
{
    public class ResponseHelper
    {
        public static GenericResponse<T> Ok<T>(T data) where T : class
        {
            return new GenericResponse<T>()
            {
                Data = data,
                ErrorMessage = string.Empty,
                Status = true
            };
        }

        public static GenericResponse<T> Fail<T>(string message) where T : class
        {
            return new GenericResponse<T>()
            {
                Data = default,
                ErrorMessage = message,
                Status = false
            };
        }
    }
}
