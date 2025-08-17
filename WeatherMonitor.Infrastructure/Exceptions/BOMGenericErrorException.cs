namespace WeatherMonitor.Infrastructure.Exceptions
{
    public class BOMGenericErrorException : Exception
    {
        public BOMGenericErrorException(string paramName, string message): base($"{paramName} - {message}") { }
    }
}
