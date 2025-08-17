using WeatherMonitor.Application.Dto;
using WeatherMonitor.Application.Exceptions;
using WeatherMonitorWebAPI.Utils;


namespace WeatherMonitorWebAPI.Filters
{
    /// <summary>
    /// A unified exception handler. This is the single point that catches all the exceptions. 
    /// So no try/catch blocks are needed anywhere else.
    /// </summary>
    public class UnifiedExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger _log;
        public UnifiedExceptionMiddleware(RequestDelegate next, Serilog.ILogger log)
        {
            _next = next;
            _log = log;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _log.Fatal(ex, "Error on processing request");
                string message = string.Empty;
                int Code = 0;
                switch (ex)
                {
                    case InvalidStationIdException: message = "Invalid station id"; Code = StatusCodes.Status400BadRequest;
                        break;
                    case InvalidMappingException: message = "Invalid data received"; Code = StatusCodes.Status502BadGateway;
                        break;
                    default:
                        message = "An error occured. Please contact support"; Code = StatusCodes.Status500InternalServerError;
                        break;
                }

                var errorData = ResponseHelper.Fail<WeatherDataDTO>(message);

                context.Response.StatusCode = Code;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(errorData);
            }
        }
    }
}
