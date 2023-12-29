#pragma warning disable IDE0005
using Azure.Identity;
#pragma warning restore IDE0005

namespace Smitenight.Presentation.Web.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureApiServices(this IServiceCollection services, IConfiguration configuration)
    {
#if !DEBUG
        builder.Configuration.AddAzureKeyVault(
            new Uri($"https://{configuration["KeyVaultSettings:Url"]}.vault.azure.net/"),
            new DefaultAzureCredential());
#endif

        return services;
    }
}
