using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smitenight.Persistence.Data.EntityFramework.Secrets;

namespace Smitenight.Persistence.Data.EntityFramework.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<DatabaseSecrets>(configuration.GetSection(nameof(DatabaseSecrets)));

            serviceCollection.AddDbContext<SmitenightDbContext>(x =>
            {
                var connectionString = configuration[$"{nameof(DatabaseSecrets)}:{nameof(DatabaseSecrets.ConnectionString)}"];
                x.UseSqlServer(connectionString);
            });
        }
    }
}
