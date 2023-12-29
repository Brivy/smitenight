using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Cache;
using Smitenight.Providers.SmiteProvider.HiRez.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets.Validators;
using Smitenight.Providers.SmiteProvider.HiRez.Services;
using Smitenight.Providers.SmiteProvider.HiRez.Settings;
using Smitenight.Providers.SmiteProvider.HiRez.Settings.Validators;
using Smitenight.Utilities.Configuration.Common.Extensions;
using Smitenight.Utilities.Mapper.Extensions;

namespace Smitenight.Providers.SmiteProvider.HiRez.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureSmiteProviderServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMappers(typeof(ServiceCollectionExtensions).Assembly);

        services.AddOptions<SmiteClientSettings>().Bind(configuration.GetSection(nameof(SmiteClientSettings))).ValidateOnStart();
        services.AddOptions<SmiteClientSecrets>().Bind(configuration.GetSection(nameof(SmiteClientSecrets))).ValidateOnStart();

        services
            .AddSingleton<IValidateOptions<SmiteClientSettings>, SmiteClientSettingsValidator>()
            .AddSingleton<IValidateOptions<SmiteClientSecrets>, SmiteClientSecretsValidator>();

        services
            .AddScoped<ISmiteSessionCacheService, SmiteSessionCacheService>()
            .AddScoped<ISmiteClientUrlService, SmiteClientUrlService>()
            .AddScoped<ISmiteHashService, SmiteHashService>();

        services.AddHttpClient<ISmiteClient, SmiteClient>(client =>
        {
            configuration.ValidateConfiguration<SmiteClientSettings, SmiteClientSettingsValidator>();

            string url = configuration[$"{nameof(SmiteClientSettings)}:{nameof(SmiteClientSettings.Url)}"] ?? throw new NullReferenceException();
            client.BaseAddress = new Uri(url);
        });

        services.AddHttpClient<ISmiteSessionClient, SmiteSessionClient>(client =>
        {
            configuration.ValidateConfiguration<SmiteClientSettings, SmiteClientSettingsValidator>();

            string url = configuration[$"{nameof(SmiteClientSettings)}:{nameof(SmiteClientSettings.Url)}"] ?? throw new NullReferenceException();
            client.BaseAddress = new Uri(url);
        });

        return services;
    }
}
