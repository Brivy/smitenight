using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SmitenightApp.CompositionRoot
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            Application.Startup.ConfigureServices(serviceCollection);
            Infrastructure.KeyVault.Startup.ConfigureServices(serviceCollection, configuration);
            Infrastructure.RedisCache.Startup.ConfigureServices(serviceCollection, configuration);
            Infrastructure.SmiteClient.Startup.ConfigureServices(serviceCollection, configuration);
            Persistence.Startup.ConfigureServices(serviceCollection, configuration);
        }
    }
}
