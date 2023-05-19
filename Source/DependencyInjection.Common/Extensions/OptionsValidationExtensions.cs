using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Smitenight.Utilities.DependencyInjection.Common.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class OptionsValidationExtensions
    {
        public static IServiceCollection AddOptionsWithValidation<TOptions>(this IServiceCollection services, IConfiguration config) where TOptions : class
        {
            services.ConfigureAndValidate<TOptions>(config.Bind);
            return services;
        }

        public static IServiceCollection AddOptionsWithValidation<TOptions>(this IServiceCollection services, string name, IConfiguration config) where TOptions : class
        {
            return services.AddOptions<TOptions>(name).ConfigureAndValidate(config.Bind).Services;
        }
    }
}
