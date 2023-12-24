using Microsoft.Extensions.Options;

namespace Smitenight.Providers.SmiteProvider.HiRez.Settings.Validators;

[OptionsValidator]
public partial class SmiteClientSettingsValidator : IValidateOptions<SmiteClientSettings>
{
}
