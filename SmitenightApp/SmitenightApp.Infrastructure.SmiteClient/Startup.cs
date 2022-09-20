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
            serviceCollection.AddHttpClient<IGodSmiteClient, GodSmiteClient>();
            serviceCollection.AddHttpClient<IItemSmiteClient, ItemSmiteClient>();
            serviceCollection.AddHttpClient<IRetrievePlayerSmiteClient, RetrievePlayerSmiteClient>();
            serviceCollection.AddHttpClient<IPlayerSmiteClient, PlayerSmiteClient>();
            serviceCollection.AddHttpClient<IMatchSmiteClient, MatchSmiteClient>();
            serviceCollection.AddHttpClient<ILeagueSmiteClient, LeagueSmiteClient>();
            serviceCollection.AddHttpClient<ITeamSmiteClient, TeamSmiteClient>();
            serviceCollection.AddHttpClient<IOtherSmiteClient, OtherSmiteSmiteClient>();
        }
    }
}
