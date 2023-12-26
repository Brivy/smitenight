using Microsoft.Extensions.Configuration;
using Smitenight.Utilities.Cache.Redis.Secrets;

namespace Smitenight.Utilities.Cache.Redis.Extensions;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder ConfigureCacheSecrets(this IConfigurationBuilder configurationBuilder)
    {
        return configurationBuilder.AddUserSecrets<RedisSecrets>();
    }
}
