using Microsoft.Extensions.Options;

namespace Smitenight.Utilities.Cache.Redis.Secrets.Validators;

[OptionsValidator]
public partial class RedisSecretsValidator : IValidateOptions<RedisSecrets>
{
}
