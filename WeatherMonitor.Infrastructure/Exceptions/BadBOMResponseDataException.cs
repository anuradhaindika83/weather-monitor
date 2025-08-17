namespace WeatherMonitor.Infrastructure.Exceptions
{
    public class BadBOMResponseDataException : Exception
    {
        public BadBOMResponseDataException(string paramName)
            : base("Bad data received from the BOM API", new ArgumentNullException(paramName)) { }
            
    }
}
