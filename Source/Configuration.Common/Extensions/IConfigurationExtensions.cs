using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Smitenight.Utilities.Configuration.Common.Extensions;

public static class IConfigurationExtensions
{
    public static void ValidateConfiguration<TConfiguration, TConfigurationValidator>(this IConfiguration configuration)
        where TConfiguration : class
        where TConfigurationValidator : class, IValidateOptions<TConfiguration>, new()
    {
        string sectionName = typeof(TConfiguration).Name;
        TConfiguration? configurationObject = configuration.GetSection(sectionName).Get<TConfiguration>() ?? throw new NullReferenceException($"Configuration section {sectionName} is null.");
        TConfigurationValidator validator = new();
        ValidateOptionsResult validationResult = validator.Validate(null, configurationObject);
        if (!validationResult.Succeeded)
        {
            throw new OptionsValidationException(sectionName, typeof(TConfiguration), validationResult.Failures);
        }
    }
}
