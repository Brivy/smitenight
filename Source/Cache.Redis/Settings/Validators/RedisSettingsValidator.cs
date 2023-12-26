using Microsoft.Extensions.Options;

namespace Smitenight.Utilities.Cache.Redis.Settings.Validators;

[OptionsValidator]
internal partial class RedisSettingsValidator : IValidateOptions<RedisSettings>
{
}
