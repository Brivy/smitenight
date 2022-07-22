using Microsoft.Extensions.DependencyInjection;
using Smitenight.Abstractions.Application.Services.Maintenance;
using Smitenight.Application.Services.Maintenance;

namespace Smitenight.Application
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMaintainSmitenight, MaintainSmitenight>();
            serviceCollection.AddScoped<IMaintainItemsService, MaintainItemsService>();
            serviceCollection.AddScoped<IMaintainGodsService, MaintainGodsService>();
        }
    }
}
