using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Options;
using Smitenight.Infrastructure.KeyVault.Settings;

namespace Smitenight.Infrastructure.KeyVault.Factories
{
    public class SecretClientFactory
    {
        private readonly KeyVaultSettings _keyVaultSettings;

        public SecretClientFactory(IOptions<KeyVaultSettings> keyVaultSettings)
        {
            _keyVaultSettings = keyVaultSettings.Value;
        }

        public SecretClient? Create()
        {
            var options = new SecretClientOptions
            {
                Retry = {
                    Delay = TimeSpan.FromSeconds(2),
                    MaxDelay = TimeSpan.FromSeconds(16),
                    MaxRetries = 3,
                    Mode = RetryMode.Exponential
                }
            };

            var keyVaultUrl = _keyVaultSettings.Url;
            return keyVaultUrl != null 
                ? new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential(), options) 
                : null;
        }
    }
}
