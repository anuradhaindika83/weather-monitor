namespace WeatherMonitor.Infrastructure
{
    public class BOMOptions
    {
        public const string Section = "BOMOptions";
        public required string Url { get; set; }
        public required string ProductID { get; set; }
    }
}
