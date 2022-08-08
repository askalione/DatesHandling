using DatesHandling.DataAccess.Interfaces;
using DatesHandling.DataAccess.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessPostgreSql(this IServiceCollection services, string connectionString)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (string.IsNullOrWhiteSpace(connectionString) == true)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            services.AddDbContext<IDbContext, AppDbContext>(dbContextOptions =>
            {
                dbContextOptions
                    .UseNpgsql(connectionString)
                    .UseSnakeCaseNamingConvention();
            });

            return services;
        }
    }
}
