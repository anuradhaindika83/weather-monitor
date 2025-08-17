namespace WeatherMonitor.Application.Exceptions
{
    public class InvalidMappingException : Exception
    {
        public InvalidMappingException(string paramName, string message) 
            :base($"Invalid mapping for the {paramName}.{message}", new ArgumentException("Invalid data point"))
        { }
    }
}
