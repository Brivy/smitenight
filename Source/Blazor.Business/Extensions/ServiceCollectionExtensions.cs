using Microsoft.Extensions.DependencyInjection;
using Smitenight.Application.Blazor.Business.Contracts.Services.Checksums;
using Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;
using Smitenight.Application.Blazor.Business.Services.Checksums;
using Smitenight.Application.Blazor.Business.Services.Maintenance;
using Smitenight.Utilities.Mapper.Common.Extensions;

namespace Smitenight.Application.Blazor.Business.Extensions
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMappers(typeof(Startup).Assembly);

            serviceCollection
                .AddScoped<IChecksumService, ChecksumService>()
                .AddScoped<IMaintainGodsService, MaintainGodsService>()
                .AddScoped<IMaintainItemsService, MaintainItemsService>()
                .AddScoped<IMaintainSmitenight, MaintainSmitenight>();
        }
    }
}
