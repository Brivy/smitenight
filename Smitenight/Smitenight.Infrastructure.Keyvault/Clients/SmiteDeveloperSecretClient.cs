using Azure.Security.KeyVault.Secrets;
using Smitenight.Abstractions.Infrastructure.KeyVault;
using Smitenight.Domain.Secrets;
using Smitenight.Infrastructure.KeyVault.Constants;
using Smitenight.Infrastructure.KeyVault.Factories;

namespace Smitenight.Infrastructure.KeyVault.Clients
{
    public class SmiteDeveloperSecretClient : KeyVaultClient<SmiteDeveloperSecrets>, ISmiteDeveloperSecretClient
    {
        public SmiteDeveloperSecretClient(SecretClientFactory secretClientFactory) : base(secretClientFactory)
        {
        }

        public override async Task<SmiteDeveloperSecrets?> GetSecrets()
        {
            var devId = await Client.GetSecretAsync(SmiteDeveloperSecretConstants.DeveloperIdVariableName);
            var authKey = await Client.GetSecretAsync(SmiteDeveloperSecretConstants.AuthenticationKeyVariableName);

            if (devId?.Value?.Value == null ||
                authKey?.Value?.Value == null ||
                !int.TryParse(devId.Value.Value, out var parsedDevId))
            {
                return null;
            }

            var smiteDeveloperSecrets = new SmiteDeveloperSecrets(parsedDevId, authKey.Value.Value);
            return smiteDeveloperSecrets;
        }
    }
}
