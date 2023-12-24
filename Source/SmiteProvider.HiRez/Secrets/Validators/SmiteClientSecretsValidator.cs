using Microsoft.Extensions.Options;

namespace Smitenight.Providers.SmiteProvider.HiRez.Secrets.Validators;

[OptionsValidator]
public partial class SmiteClientSecretsValidator : IValidateOptions<SmiteClientSecrets>
{
}
