using Microsoft.Extensions.DependencyInjection;

namespace WeatherMonitor.Domain.Extensions
{
    public static class DomainDISettingsExtension
    {
        public static IServiceCollection ConfigureDomain(this IServiceCollection services)
        {
            return services.AddTransient<IDomainService, DomainService>()
                .AddTransient<IDataPointService, DataPointService>();
        }
    }
}
