using Microsoft.Extensions.DependencyInjection;
using Smitenight.Application.Core.Business.Contracts.Services.Checksums;
using Smitenight.Application.Core.Business.Contracts.Services.Maintenance;
using Smitenight.Application.Core.Business.Services.Checksums;
using Smitenight.Application.Core.Business.Services.Maintenance;
using Smitenight.Utilities.Mapper.Extensions;

namespace Smitenight.Application.Core.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureBusinessServices(this IServiceCollection services)
        {
            services.AddMappers(typeof(ServiceCollectionExtensions).Assembly);

            services
                .AddScoped<IChecksumService, ChecksumService>()
                .AddScoped<IMaintainGodsService, MaintainGodsService>()
                .AddScoped<IMaintainItemsService, MaintainItemsService>()
                .AddScoped<IMaintainPatchesService, MaintainPatchesService>()
                .AddScoped<IMaintainSmitenight, MaintainSmitenight>();

            return services;
        }
    }
}
