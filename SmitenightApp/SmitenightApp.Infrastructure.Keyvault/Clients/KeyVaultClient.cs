using Azure.Security.KeyVault.Secrets;
using SmitenightApp.Infrastructure.KeyVault.Factories;

namespace SmitenightApp.Infrastructure.KeyVault.Clients
{
    public abstract class KeyVaultClient<TSecrets>
        where TSecrets : class
    {
        protected SecretClient Client;

        protected KeyVaultClient(SecretClientFactory secretClientFactory)
        {
            Client = secretClientFactory.Create() ?? throw new NullReferenceException();
        }

        public abstract Task<TSecrets?> GetSecrets();
    }
}
