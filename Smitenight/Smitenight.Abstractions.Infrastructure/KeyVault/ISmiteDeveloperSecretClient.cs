using Smitenight.Domain.Secrets;

namespace Smitenight.Abstractions.Infrastructure.KeyVault;

public interface ISmiteDeveloperSecretClient
{
    Task<SmiteDeveloperSecrets?> GetSecrets();
}