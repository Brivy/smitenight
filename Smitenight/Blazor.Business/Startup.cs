using Microsoft.Extensions.DependencyInjection;
using Smitenight.Application.Blazor.Business.Contracts.Facades.SmiteClient;
using Smitenight.Application.Blazor.Business.Contracts.Services.Builders;
using Smitenight.Application.Blazor.Business.Contracts.Services.Cache;
using Smitenight.Application.Blazor.Business.Contracts.Services.Common;
using Smitenight.Application.Blazor.Business.Contracts.Services.Gods;
using Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;
using Smitenight.Application.Blazor.Business.Contracts.Services.Matches;
using Smitenight.Application.Blazor.Business.Contracts.Services.Players;
using Smitenight.Application.Blazor.Business.Contracts.Services.Smitenights;
using Smitenight.Application.Blazor.Business.Facades.SmiteClient;
using Smitenight.Application.Blazor.Business.Services.Builders;
using Smitenight.Application.Blazor.Business.Services.Common;
using Smitenight.Application.Blazor.Business.Services.Gods;
using Smitenight.Application.Blazor.Business.Services.Maintenance;
using Smitenight.Application.Blazor.Business.Services.Matches;
using Smitenight.Application.Blazor.Business.Services.Players;
using Smitenight.Application.Blazor.Business.Services.Smitenights;
using Smitenight.Providers.SmiteProvider.HiRez.Cache;

namespace Smitenight.Application.Blazor.Business
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            #region Facades

            serviceCollection.AddScoped<IGodSmiteClientFacade, GodSmiteClientFacade>();
            serviceCollection.AddScoped<IItemSmiteClientFacade, ItemSmiteClientFacade>();
            serviceCollection.AddScoped<ILeagueSmiteClientFacade, LeagueSmiteClientFacade>();
            serviceCollection.AddScoped<IMatchSmiteClientFacade, MatchSmiteClientFacade>();
            serviceCollection.AddScoped<IOtherSmiteClientFacade, OtherSmiteClientFacade>();
            serviceCollection.AddScoped<IPlayerSmiteClientFacade, PlayerSmiteClientFacade>();
            serviceCollection.AddScoped<IRetrievePlayerSmiteClientFacade, RetrievePlayerSmiteClientFacade>();
            serviceCollection.AddScoped<ISystemSmiteClientFacade, SystemSmiteClientFacade>();
            serviceCollection.AddScoped<ITeamSmiteClientFacade, TeamSmiteClientFacade>();

            #endregion

            #region Services

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

            // Cache services
            serviceCollection.AddScoped<ISmiteSessionCacheService, SmiteSessionCacheService>();

            // Common services
            serviceCollection.AddSingleton<IClock, Clock>();

            // Maintenance services
            serviceCollection.AddScoped<IMaintainSmitenight, MaintainSmitenight>();
            serviceCollection.AddScoped<IMaintainItemsService, MaintainItemsService>();
            serviceCollection.AddScoped<IMaintainGodsService, MaintainGodsService>();

            // Matches services
            serviceCollection.AddScoped<IImportMatchService, ImportMatchService>();

            // Player services
            serviceCollection.AddScoped<IPlayerService, PlayerService>();
            serviceCollection.AddScoped<IPlayerNameAttemptService, PlayerNameAttemptService>();

            // Smitenight services
            serviceCollection.AddScoped<ISmitenightService, SmitenightService>();

            // God services
            serviceCollection.AddScoped<IGodService, GodService>();

            #endregion
        }
    }
}
