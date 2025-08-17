using Microsoft.Extensions.Configuration;

namespace WeatherMonitor.Extensions
{
    public static class ConfigurationExtension
    {
        public static string GetItem(this IConfiguration config, string tag)
        {
            return (config[tag] ??
         throw new InvalidOperationException($"Missing configuration : {tag}. Please define it in the appsettings.json")).ToString();
        }
    }
}
