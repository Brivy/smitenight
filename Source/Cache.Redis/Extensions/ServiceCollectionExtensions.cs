using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smitenight.Utilities.Cache.Contracts.Providers;
using Smitenight.Utilities.Cache.Redis.Providers;
using Smitenight.Utilities.Cache.Redis.Secrets;
using Smitenight.Utilities.Cache.Redis.Settings;
using Smitenight.Utilities.DependencyInjection.Common.Extensions;

namespace Smitenight.Utilities.Cache.Redis.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureCacheServices(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection(nameof(RedisCacheSettings));
            services.AddOptionsWithValidation<RedisCacheSettings>(section);

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration[$"{nameof(RedisCacheSecrets)}:{nameof(RedisCacheSecrets.ConnectionString)}"];
                options.InstanceName = configuration[$"{nameof(RedisCacheSettings)}:{nameof(RedisCacheSettings.InstanceName)}"];
            });

            services.AddSingleton<IRedisCacheProvider, RedisCacheProvider>();
        }
    }
}
