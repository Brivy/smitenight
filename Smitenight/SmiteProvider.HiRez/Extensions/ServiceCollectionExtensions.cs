using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;
using Smitenight.Providers.SmiteProvider.HiRez.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Providers.SmiteProvider.HiRez.Settings;
using Smitenight.Utilities.DependencyInjection.Common.Extensions;

namespace Smitenight.Providers.SmiteProvider.HiRez.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmiteClientSecrets>(configuration.GetSection(nameof(SmiteClientSecrets)));

            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);

            var section = configuration.GetSection(nameof(SmiteClientSettings));
            services.AddOptionsWithValidation<SmiteClientSettings>(section);

            services.AddHttpClient<ISystemSmiteClient, SystemSmiteClient>();
            services.AddHttpClient<IGodSmiteClient, GodSmiteClient>();
            services.AddHttpClient<IItemSmiteClient, ItemSmiteClient>();
            services.AddHttpClient<IRetrievePlayerSmiteClient, RetrievePlayerSmiteClient>();
            services.AddHttpClient<IPlayerSmiteClient, PlayerSmiteClient>();
            services.AddHttpClient<IMatchSmiteClient, MatchSmiteClient>();
            services.AddHttpClient<ILeagueSmiteClient, LeagueSmiteClient>();
            services.AddHttpClient<ITeamSmiteClient, TeamSmiteClient>();
            services.AddHttpClient<IOtherSmiteClient, OtherSmiteSmiteClient>();
        }
    }
}
