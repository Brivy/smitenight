using System.ComponentModel.DataAnnotations;

namespace Smitenight.Persistence.Data.EntityFramework.Secrets;

internal record DatabaseSecrets
{
    [Required]
    public required string ConnectionString { get; init; }
}
