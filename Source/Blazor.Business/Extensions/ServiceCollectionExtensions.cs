using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smitenight.Application.Blazor.Business.Contracts.Services.Checksums;
using Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;
using Smitenight.Application.Blazor.Business.Services.Checksums;
using Smitenight.Application.Blazor.Business.Services.Maintenance;
using Smitenight.Persistence.Data.EntityFramework.Extensions;
using Smitenight.Providers.SmiteProvider.HiRez.Extensions;
using Smitenight.Utilities.Mapper.Extensions;

namespace Smitenight.Application.Blazor.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMappers(typeof(ServiceCollectionExtensions).Assembly);

            services.ConfigureDataServices(configuration);
            services.ConfigureSmiteProviderServices(configuration);

            services
                .AddScoped<IChecksumService, ChecksumService>()
                .AddScoped<IMaintainGodsService, MaintainGodsService>()
                .AddScoped<IMaintainItemsService, MaintainItemsService>()
                .AddScoped<IMaintainPatchesService, MaintainPatchesService>()
                .AddScoped<IMaintainSmitenight, MaintainSmitenight>();
        }
    }
}
