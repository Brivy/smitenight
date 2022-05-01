using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smitenight.Abstractions.Infrastructure.KeyVault;
using Smitenight.Infrastructure.KeyVault.Clients;
using Smitenight.Infrastructure.KeyVault.Factories;
using Smitenight.Infrastructure.KeyVault.Settings;

namespace Smitenight.Infrastructure.KeyVault
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
