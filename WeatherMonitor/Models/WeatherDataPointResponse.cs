namespace WeatherMonitor.Models
{
    public class WeatherDataPointResponse
    {
        public bool Status { get; set; }
        public List<DataPoint>? Data { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
