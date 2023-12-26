using Microsoft.Extensions.Options;

namespace Smitenight.Providers.SmiteProvider.HiRez.Secrets.Validators;

[OptionsValidator]
internal partial class SmiteClientSecretsValidator : IValidateOptions<SmiteClientSecrets>
{
}
