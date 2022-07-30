using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmitenightApp.Abstractions.Infrastructure.KeyVault;
using SmitenightApp.Infrastructure.KeyVault.Clients;
using SmitenightApp.Infrastructure.KeyVault.Factories;
using SmitenightApp.Infrastructure.KeyVault.Settings;

namespace SmitenightApp.Infrastructure.KeyVault
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions<KeyVaultSettings>()
                .Bind(configuration.GetSection(nameof(KeyVaultSettings)));

            serviceCollection.AddTransient<SecretClientFactory>();
            serviceCollection.AddTransient<ISmiteDeveloperSecretClient, SmiteDeveloperSecretClient>();
        }
    }
}
