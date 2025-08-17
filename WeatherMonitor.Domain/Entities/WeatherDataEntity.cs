 using WeatherMonitor.Domain.Attributes;

namespace WeatherMonitor.Domain.Entities
{
    public class WeatherDataEntity
    {
        public string Message { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public int SortOrder { get; set; } = default;
        public int Wmo { get; set; } = default;
        public string HistoryProduct { get; set; } = string.Empty;

        public string LocalDateTime { get; set; } = string.Empty;
        public string LocalDateTimeFull { get; set; } = string.Empty;
        public string AifstimeUtc { get; set; } = string.Empty;

        [Tag("Lat")]
        public double Lat { get; set; } = default;

        [Tag("Lon")]
        public double Lon { get; set; } = default;

        [Tag("ApparentTemperature")]
        public double ApparentTemperature { get; set; }

        [Tag("Cloud")]
        public string Cloud { get; set; } = string.Empty;

        [Tag("CloudBaseMeters")]
        public int CloudBaseMeters { get; set; }

        [Tag("CloudOktas")]
        public int CloudOktas { get; set; } = default;

        [Tag("CloudType")]
        public string CloudType { get; set; } = string.Empty;

        [Tag("CloudTypeId")]
        public object? CloudTypeId { get; set; }

        [Tag("DeltaT")]
        public double DeltaT { get; set; } = default;

        [Tag("GustKmh")]
        public int GustKmh { get; set; } = default;

        [Tag("GustKt")]
        public int GustKt { get; set; } = default;

        [Tag("AirTemperature")]
        public double AirTemperature { get; set; } = default;

        [Tag("DewPoint")]
        public double DewPoint { get; set; } = default;

        [Tag("Pressure")]
        public double Pressure { get; set; } = default;

        [Tag("PressureMsl")]
        public double PressureMsl { get; set; } = default;

        [Tag("PressureQnh")]
        public double PressureQnh { get; set; } = default;

        [Tag("PressureTrend")]
        public string PressureTrend { get; set; } = string.Empty;

        [Tag("RainTrace")]
        public string RainTrace { get; set; } = string.Empty;

        [Tag("RelativeHumidity")]
        public int RelativeHumidity { get; set; } = default;

        [Tag("SeaState")]
        public string SeaState { get; set; } = string.Empty;
        [Tag("SwellDirectionWorded")]
        public string SwellDirectionWorded { get; set; } = string.Empty;
        [Tag("SwellHeight")]
        public object? SwellHeight { get; set; } = default;
        [Tag("SwellPeriod")]
        public object? SwellPeriod { get; set; } = default;

        [Tag("VisibilityKm")]
        public string VisibilityKm { get; set; } = string.Empty;
        [Tag("Weather")]
        public string Weather { get; set; } = string.Empty;

        [Tag("WindDirection")]
        public string WindDirection { get; set; } = string.Empty;
        [Tag("WindSpeedKmh")]
        public int WindSpeedKmh { get; set; } = default;
        [Tag("WindSpeedKt")]
        public int WindSpeedKt { get; set; } = default;

    }
}
