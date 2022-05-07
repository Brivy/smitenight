using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Infrastructure.SmiteClient.Clients;
using Smitenight.Infrastructure.SmiteClient.Settings;

namespace Smitenight.Infrastructure.SmiteClient
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAutoMapper(typeof(Startup).Assembly);

            serviceCollection.AddOptions<SmiteClientSettings>()
                .Bind(configuration.GetSection(nameof(SmiteClientSettings)));

            serviceCollection.AddHttpClient<ISystemSmiteClient, SystemSmiteClient>();
            serviceCollection.AddHttpClient<IGodSmiteClient, GodSmiteClient>();
        }
    }
}
