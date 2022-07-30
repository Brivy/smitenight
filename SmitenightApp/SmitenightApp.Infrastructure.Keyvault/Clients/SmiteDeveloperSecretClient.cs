using SmitenightApp.Abstractions.Infrastructure.KeyVault;
using SmitenightApp.Domain.Secrets;
using SmitenightApp.Infrastructure.KeyVault.Constants;
using SmitenightApp.Infrastructure.KeyVault.Factories;

namespace SmitenightApp.Infrastructure.KeyVault.Clients
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
