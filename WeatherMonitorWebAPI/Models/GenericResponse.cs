namespace WeatherMonitorWebAPI.Models
{
    public class GenericResponse<T> where T : class
    {
        public bool Status { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
