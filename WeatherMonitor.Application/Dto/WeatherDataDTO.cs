using WeatherMonitor.Domain.Attributes;

namespace WeatherMonitor.Application.Dto
{
    public class WeatherDataDTO
    {
        public double AverageTemperature { get; set; }
        public List<WeatherDataItem>? Items { get; set; }
    }

    public class WeatherDataItem
    {
        public string Message { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int SortOrder { get; set; } = default;
        public int Wmo { get; set; } = default;
        public string HistoryProduct { get; set; } = string.Empty;
        public string LocalDateTime { get; set; } = string.Empty;
        public string LocalDateTimeFull { get; set; } = string.Empty;
        public string AifstimeUtc { get; set; } = string.Empty;
        public double Lat { get; set; } = default;
        public double Lon { get; set; } = default;
        public double ApparentTemperature { get; set; }
        public string Cloud { get; set; } = string.Empty;
        public int CloudBaseMeters { get; set; }
        public int CloudOktas { get; set; } = default;
        public string CloudType { get; set; } = string.Empty;
        public object? CloudTypeId { get; set; }
        public double DeltaT { get; set; } = default;
        public int GustKmh { get; set; } = default;
        public int GustKt { get; set; } = default;
        public double AirTemperature { get; set; } = default;
        public double DewPoint { get; set; } = default;
        public double Pressure { get; set; } = default;
        public double PressureMsl { get; set; } = default;
        public double PressureQnh { get; set; } = default;
        public string PressureTrend { get; set; } = string.Empty;
        public string RainTrace { get; set; } = string.Empty;
        public int RelativeHumidity { get; set; } = default;
        public string SeaState { get; set; } = string.Empty;
        public string SwellDirectionWorded { get; set; } = string.Empty;
        public object? SwellHeight { get; set; } = default;
        public object? SwellPeriod { get; set; } = default;
        public string VisibilityKm { get; set; } = string.Empty;
        public string Weather { get; set; } = string.Empty;
        public string WindDirection { get; set; } = string.Empty;
        public int WindSpeedKmh { get; set; } = default;
        public int WindSpeedKt { get; set; } = default;
    }
}
