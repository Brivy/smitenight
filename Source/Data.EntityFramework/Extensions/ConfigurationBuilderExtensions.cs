using Microsoft.Extensions.Configuration;
using Smitenight.Persistence.Data.EntityFramework.Secrets;

namespace Smitenight.Persistence.Data.EntityFramework.Extensions;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder ConfigureDataSecrets(this IConfigurationBuilder configurationBuilder)
    {
        return configurationBuilder.AddUserSecrets<DatabaseSecrets>();
    }
}
