using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Smitenight.Utilities.Cache.Contracts.Providers;
using Smitenight.Utilities.Cache.Redis.Providers;
using Smitenight.Utilities.Cache.Redis.Secrets;
using Smitenight.Utilities.Cache.Redis.Secrets.Validators;
using Smitenight.Utilities.Cache.Redis.Settings;
using Smitenight.Utilities.Cache.Redis.Settings.Validators;
using Smitenight.Utilities.Configuration.Common.Extensions;

namespace Smitenight.Utilities.Cache.Redis.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureCacheServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RedisSettings>(configuration.GetSection(nameof(RedisSettings)));
        services.Configure<RedisSecrets>(configuration.GetSection(nameof(RedisSecrets)));

        services
            .AddSingleton<IValidateOptions<RedisSettings>, RedisSettingsValidator>()
            .AddSingleton<IRedisCacheProvider, RedisCacheProvider>();

        services.AddStackExchangeRedisCache(options =>
        {
            configuration.ValidateConfiguration<RedisSettings, RedisSettingsValidator>();
            configuration.ValidateConfiguration<RedisSecrets, RedisSecretsValidator>();

            options.Configuration = configuration[$"{nameof(RedisSecrets)}:{nameof(RedisSecrets.ConnectionString)}"];
            options.InstanceName = configuration[$"{nameof(RedisSettings)}:{nameof(RedisSettings.InstanceName)}"]; ;
        });

        return services;
    }
}
