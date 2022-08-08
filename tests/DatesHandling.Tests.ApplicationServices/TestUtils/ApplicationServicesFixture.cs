using DatesHandling.DataAccess.PostgreSql;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Respawn;
using Structr.Abstractions.Helpers;

namespace DatesHandling.Tests.ApplicationServices.TestUtils
{
    public class ApplicationServicesFixture : IDisposable
    {
        private const string ConnectionString = @"Host=localhost;Port=5432;Database=tests_dates_handling;Username=some_user;Password=some_password";

        private readonly IServiceProvider _serviceProvider;

        public ApplicationServicesFixture()
        {
            var services = new ServiceCollection();

            services.AddDataAccessPostgreSql(ConnectionString);
            services.AddApplicationServices();

            _serviceProvider = services.BuildServiceProvider();

            var dbContext = _serviceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.EnsureCreated();

            ResetDatabase();
        }

        public TService GetApplicationService<TService>() where TService : class
        {
            return _serviceProvider.GetRequiredService<TService>();
        }

        public void Dispose()
        {
            ResetDatabase();
        }

        private readonly Checkpoint _checkpoint = new()
        {
            SchemasToInclude = new[]
            {
                "public"
            },
            DbAdapter = DbAdapter.Postgres,
            WithReseed = true
        };

        private void ResetDatabase()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                AsyncHelper.RunSync(() => _checkpoint.Reset(connection));
            }
        }
    }
}
