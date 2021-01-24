using Microsoft.Extensions.DependencyInjection;
using WebAPI1.Services;

namespace WebAPI1.Extenssions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProcessor, Processor>();
            services.AddHttpClient<IGeneratorManager, GeneratorManager>();
            services.AddScoped<IMultiplierManager, MultiplierManager>();
            services.AddHostedService<ProcessService>();
            return services;
        }
    }
}
