using Microsoft.Extensions.Options;

namespace Smitenight.Utilities.Cache.Redis.Settings.Validators;

[OptionsValidator]
public partial class RedisSettingsValidator : IValidateOptions<RedisSettings>
{
}
