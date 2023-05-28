using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Cache;
using Smitenight.Providers.SmiteProvider.HiRez.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Providers.SmiteProvider.HiRez.Services;
using Smitenight.Providers.SmiteProvider.HiRez.Settings;
using Smitenight.Utilities.DependencyInjection.Common.Extensions;
using Smitenight.Utilities.Mapper.Common.Extensions;

namespace Smitenight.Providers.SmiteProvider.HiRez.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureSmiteProviderServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMappers(typeof(ServiceCollectionExtensions).Assembly);

            var smiteClientSecrets = configuration.GetSection(nameof(SmiteClientSecrets));
            var smiteClientSettings = configuration.GetSection(nameof(SmiteClientSettings));
            services.AddOptionsWithValidation<SmiteClientSecrets>(smiteClientSecrets);
            services.AddOptionsWithValidation<SmiteClientSettings>(smiteClientSettings);

            var settings = smiteClientSettings.Get<SmiteClientSettings>() ?? throw new NullReferenceException();
            services.AddHttpClient<ISmiteClient, SmiteClient>(client =>
            {
                client.BaseAddress = new Uri(settings.Url);
            });

            services.AddHttpClient<ISmiteSessionClient, SmiteSessionClient>(client =>
            {
                client.BaseAddress = new Uri(settings.Url);
            });

            services
                .AddScoped<ISmiteSessionCacheService, SmiteSessionCacheService>()
                .AddScoped<ISmiteClientUrlService, SmiteClientUrlService>()
                .AddScoped<ISmiteHashService, SmiteHashService>();
        }
    }
}
