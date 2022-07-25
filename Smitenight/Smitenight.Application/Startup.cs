using Microsoft.Extensions.DependencyInjection;
using Smitenight.Abstractions.Application.Services.Maintenance;
using Smitenight.Abstractions.Application.Services.System;
using Smitenight.Application.Services.Common;
using Smitenight.Application.Services.Maintenance;
using Smitenight.Application.Services.System;

namespace Smitenight.Application
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Common services
            serviceCollection.AddSingleton<IClock, Clock>();

            // Maintenance services
            serviceCollection.AddScoped<IMaintainSmitenight, MaintainSmitenight>();
            serviceCollection.AddScoped<IMaintainItemsService, MaintainItemsService>();
            serviceCollection.AddScoped<IMaintainGodsService, MaintainGodsService>();

            // System services
            serviceCollection.AddScoped<ISmiteSessionService, SmiteSessionService>();
        }
    }
}
