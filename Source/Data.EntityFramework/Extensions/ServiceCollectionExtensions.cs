using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smitenight.Persistence.Data.Contracts.Repositories;
using Smitenight.Persistence.Data.EntityFramework.Repositories;
using Smitenight.Persistence.Data.EntityFramework.Secrets;
using Smitenight.Utilities.DependencyInjection.Common.Extensions;
using Smitenight.Utilities.Mapper.Common.Extensions;

namespace Smitenight.Persistence.Data.EntityFramework.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMappers(typeof(ServiceCollectionExtensions).Assembly);

            var databaseSecrets = configuration.GetSection(nameof(DatabaseSecrets));
            services.AddOptionsWithValidation<DatabaseSecrets>(databaseSecrets);

            services.AddDbContext<SmitenightDbContext>(x =>
            {
                var connectionString = configuration[$"{nameof(DatabaseSecrets)}:{nameof(DatabaseSecrets.ConnectionString)}"];
                x.UseSqlServer(connectionString);
            });

            services
                .AddScoped<IMaintainGodsRepository, MaintainGodsRepository>()
                .AddScoped<IMaintainItemsRepository, MaintainItemsRepository>()
                .AddScoped<IMaintainPatchesRepository, MaintainPatchesRepository>();
        }
    }
}
