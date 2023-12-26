using Microsoft.Extensions.Configuration;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;

namespace Smitenight.Providers.SmiteProvider.HiRez.Extensions;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder ConfigureSmiteProviderSecrets(this IConfigurationBuilder configurationBuilder)
    {
        return configurationBuilder.AddUserSecrets<SmiteClientSecrets>();
    }
}
