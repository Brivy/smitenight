using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmitenightApp.Abstractions.Infrastructure.RedisCache.Providers;
using SmitenightApp.Infrastructure.RedisCache.Providers;
using SmitenightApp.Infrastructure.RedisCache.Secrets;
using SmitenightApp.Infrastructure.RedisCache.Settings;

namespace SmitenightApp.Infrastructure.RedisCache
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions<RedisCacheSettings>()
                .Bind(configuration.GetSection(nameof(RedisCacheSettings)));

            serviceCollection.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration[$"{nameof(RedisCacheSecrets)}:{nameof(RedisCacheSecrets.ConnectionString)}"];
                options.InstanceName = configuration[$"{nameof(RedisCacheSettings)}:{nameof(RedisCacheSettings.InstanceName)}"];
            });

            serviceCollection.AddSingleton<IRedisCacheProvider, RedisCacheProvider>();
        }
    }
}
