using Microsoft.Extensions.DependencyInjection;
using Smitenight.Abstractions.Application.Services.Builders;
using Smitenight.Abstractions.Application.Services.Maintenance;
using Smitenight.Abstractions.Application.Services.Matches;
using Smitenight.Abstractions.Application.Services.System;
using Smitenight.Application.Services.Builders;
using Smitenight.Application.Services.Common;
using Smitenight.Application.Services.Maintenance;
using Smitenight.Application.Services.Matches;
using Smitenight.Application.Services.System;

namespace Smitenight.Application
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Builder services
            serviceCollection.AddScoped<IActivePurchaseBuilderService, ActivePurchaseBuilderService>();
            serviceCollection.AddScoped<IGodBanBuilderService, GodBanBuilderService>();
            serviceCollection.AddScoped<IGodBuilderService, GodBuilderService>();
            serviceCollection.AddScoped<IItemBuilderService, ItemBuilderService>();
            serviceCollection.AddScoped<IItemPurchaseBuilderService, ItemPurchaseBuilderService>();
            serviceCollection.AddScoped<IMatchBuilderService, MatchBuilderService>();
            serviceCollection.AddScoped<IMatchDetailBuilderService, MatchDetailBuilderService>();
            serviceCollection.AddScoped<IPlayerBuilderService, PlayerBuilderService>();

            // Common services
            serviceCollection.AddSingleton<IClock, Clock>();

            // Maintenance services
            serviceCollection.AddScoped<IMaintainSmitenight, MaintainSmitenight>();
            serviceCollection.AddScoped<IMaintainItemsService, MaintainItemsService>();
            serviceCollection.AddScoped<IMaintainGodsService, MaintainGodsService>();

            // Matches services
            serviceCollection.AddScoped<IImportMatchService, ImportMatchService>();

            // System services
            serviceCollection.AddScoped<ISmiteSessionService, SmiteSessionService>();
        }
    }
}
