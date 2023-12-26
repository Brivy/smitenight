using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smitenight.Utilities.Configuration.Common.Extensions;
using Smitenight.Persistence.Data.Contracts.Repositories;
using Smitenight.Persistence.Data.EntityFramework.Repositories;
using Smitenight.Persistence.Data.EntityFramework.Secrets;
using Smitenight.Persistence.Data.EntityFramework.Secrets.Validators;
using Smitenight.Utilities.Mapper.Extensions;

namespace Smitenight.Persistence.Data.EntityFramework.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMappers(typeof(ServiceCollectionExtensions).Assembly);

        services.Configure<DatabaseSecrets>(configuration.GetSection(nameof(DatabaseSecrets)));

        services
            .AddScoped<IMaintainGodsRepository, MaintainGodsRepository>()
            .AddScoped<IMaintainItemsRepository, MaintainItemsRepository>()
            .AddScoped<IMaintainPatchesRepository, MaintainPatchesRepository>();

        services.AddDbContext<SmitenightDbContext>(x =>
        {
            configuration.ValidateConfiguration<DatabaseSecrets, DatabaseSecretsValidator>();

            string? connectionString = configuration[$"{nameof(DatabaseSecrets)}:{nameof(DatabaseSecrets.ConnectionString)}"];
            x.UseSqlServer(connectionString);
        });

        return services;
    }
}
