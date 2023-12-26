using System.ComponentModel.DataAnnotations;

namespace Smitenight.Utilities.Cache.Redis.Secrets;

internal record RedisSecrets
{
    [Required]
    public required string ConnectionString { get; init; }
}
