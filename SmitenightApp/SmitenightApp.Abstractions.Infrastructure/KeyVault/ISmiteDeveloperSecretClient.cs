using SmitenightApp.Domain.Secrets;

namespace SmitenightApp.Abstractions.Infrastructure.KeyVault;

public interface ISmiteDeveloperSecretClient
{
    Task<SmiteDeveloperSecrets?> GetSecrets();
}