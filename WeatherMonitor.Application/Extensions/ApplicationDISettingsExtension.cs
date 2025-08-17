using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherMonitor.Domain.Extensions;
using WeatherMonitor.Infrastructure.Extensions;

namespace WeatherMonitor.Application.Extensions
{
    public static class ApplicationDISettingsExtension
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(ApplicationDISettingsExtension).Assembly;
           return services.AddValidatorsFromAssembly(assembly)
                .ConfigureInfrastructure(configuration)
                .ConfigureDomain()
                .AddScoped<IWeatherDataService, WeatherDataService>();
          
        }
    }
}
