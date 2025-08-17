using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace WeatherMonitor.Infrastructure.Extensions
{
    public static class InfrastructureDISettingsExtension
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            return service
                .AddHttpClient()
                 .Configure<BOMOptions>(configuration.GetSection(BOMOptions.Section))
                .AddScoped<IBOMApiClient, BOMApiClient>();
        }
    }
}
