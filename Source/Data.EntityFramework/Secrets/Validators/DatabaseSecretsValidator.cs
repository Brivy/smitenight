using Microsoft.Extensions.Options;

namespace Smitenight.Persistence.Data.EntityFramework.Secrets.Validators;

[OptionsValidator]
internal partial class DatabaseSecretsValidator : IValidateOptions<DatabaseSecrets>
{
}
