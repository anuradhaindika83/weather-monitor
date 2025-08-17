namespace WeatherMonitor.Application.Extensions
{
    public static class FormatExtension
    {
        public static string Sanitize(this string? value) =>  (value ?? string.Empty).Trim();
        public static double Sanitize(this double? value) => value ?? 0;
        public static int Sanitize(this int? value) => value ?? 0;

    }
}
