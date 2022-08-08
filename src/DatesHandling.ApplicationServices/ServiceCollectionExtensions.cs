using DatesHandling.ApplicationServices;
using DatesHandling.ApplicationServices.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IBarService, BarService>();
            services.AddScoped<IBazService, BazService>();
            services.AddScoped<IFooService, FooService>();

            return services;
        }
    }
}
