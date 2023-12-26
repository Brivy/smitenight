using Microsoft.Extensions.Options;

namespace Smitenight.Utilities.Cache.Redis.Secrets.Validators;

[OptionsValidator]
internal partial class RedisSecretsValidator : IValidateOptions<RedisSecrets>
{
}
