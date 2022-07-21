using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Smitenight.CompositionRoot
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            Application.Startup.ConfigureServices(serviceCollection);
            Infrastructure.KeyVault.Startup.ConfigureServices(serviceCollection, configuration);
            Infrastructure.SmiteClient.Startup.ConfigureServices(serviceCollection, configuration);
            Persistence.Startup.ConfigureServices(serviceCollection, configuration);
        }
    }
}
