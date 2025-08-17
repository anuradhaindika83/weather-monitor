namespace WeatherMonitor.Application.Exceptions
{
    public class InvalidStationIdException : Exception
    {
        public InvalidStationIdException() : base("Invalid station id provided") { }
    }
}
