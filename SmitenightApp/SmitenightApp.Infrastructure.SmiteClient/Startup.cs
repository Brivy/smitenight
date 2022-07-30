using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Infrastructure.SmiteClient.Clients;
using SmitenightApp.Infrastructure.SmiteClient.Secrets;
using SmitenightApp.Infrastructure.SmiteClient.Settings;

namespace SmitenightApp.Infrastructure.SmiteClient
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<SmiteClientSecrets>(configuration.GetSection(nameof(SmiteClientSecrets)));

            serviceCollection.AddAutoMapper(typeof(Startup).Assembly);

            serviceCollection.AddOptions<SmiteClientSettings>()
                .Bind(configuration.GetSection(nameof(SmiteClientSettings)));

            serviceCollection.AddHttpClient<ISystemSmiteClient, SystemSmiteClient>();
            serviceCollection.AddHttpClient<IGodSmiteClient, GodClient>();
            serviceCollection.AddHttpClient<IItemSmiteClient, ItemClient>();
            serviceCollection.AddHttpClient<IRetrievePlayerClient, RetrievePlayerClient>();
            serviceCollection.AddHttpClient<IPlayerInfoClient, PlayerClient>();
            serviceCollection.AddHttpClient<IMatchInfoClient, MatchClient>();
            serviceCollection.AddHttpClient<ILeagueClient, LeagueClient>();
            serviceCollection.AddHttpClient<ITeamClient, TeamClient>();
            serviceCollection.AddHttpClient<IOtherClient, OtherClient>();
        }
    }
}
