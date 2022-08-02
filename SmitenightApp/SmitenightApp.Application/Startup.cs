using Microsoft.Extensions.DependencyInjection;
using SmitenightApp.Abstractions.Application.Services.Builders;
using SmitenightApp.Abstractions.Application.Services.Common;
using SmitenightApp.Abstractions.Application.Services.Maintenance;
using SmitenightApp.Abstractions.Application.Services.Matches;
using SmitenightApp.Abstractions.Application.Services.Smitenights;
using SmitenightApp.Abstractions.Application.Services.System;
using SmitenightApp.Application.Services.Builders;
using SmitenightApp.Application.Services.Common;
using SmitenightApp.Application.Services.Maintenance;
using SmitenightApp.Application.Services.Matches;
using SmitenightApp.Application.Services.Smitenights;
using SmitenightApp.Application.Services.System;

namespace SmitenightApp.Application
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
            serviceCollection.AddScoped<ISmitenightBuilderService, SmitenightBuilderService>();

            // Common services
            serviceCollection.AddSingleton<IClock, Clock>();

            // Maintenance services
            serviceCollection.AddScoped<IMaintainSmitenight, MaintainSmitenight>();
            serviceCollection.AddScoped<IMaintainItemsService, MaintainItemsService>();
            serviceCollection.AddScoped<IMaintainGodsService, MaintainGodsService>();

            // Matches services
            serviceCollection.AddScoped<IImportMatchService, ImportMatchService>();

            // Smitenight services
            serviceCollection.AddScoped<ISmitenightService, SmitenightService>();

            // System services
            serviceCollection.AddScoped<ISmiteSessionService, SmiteSessionService>();
        }
    }
}
