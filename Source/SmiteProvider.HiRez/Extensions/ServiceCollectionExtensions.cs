using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Cache;
using Smitenight.Providers.SmiteProvider.HiRez.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Providers.SmiteProvider.HiRez.Services;
using Smitenight.Providers.SmiteProvider.HiRez.Settings;
using Smitenight.Providers.SmiteProvider.HiRez.Settings.Validators;
using Smitenight.Utilities.Configuration.Common.Extensions;
using Smitenight.Utilities.Mapper.Extensions;

namespace Smitenight.Providers.SmiteProvider.HiRez.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureSmiteProviderServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMappers(typeof(ServiceCollectionExtensions).Assembly);

        services.Configure<SmiteClientSettings>(configuration.GetSection(nameof(SmiteClientSettings)));
        services.Configure<SmiteClientSecrets>(configuration.GetSection(nameof(SmiteClientSecrets)));

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

        services
            .AddScoped<ISmiteSessionCacheService, SmiteSessionCacheService>()
            .AddScoped<ISmiteClientUrlService, SmiteClientUrlService>()
            .AddScoped<ISmiteHashService, SmiteHashService>();
    }
}
