using Microsoft.Extensions.Options;

namespace Smitenight.Persistence.Data.EntityFramework.Secrets.Validators;

[OptionsValidator]
public partial class DatabaseSecretsValidator : IValidateOptions<DatabaseSecrets>
{
}
