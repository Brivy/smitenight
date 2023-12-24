using System.ComponentModel.DataAnnotations;

namespace Smitenight.Utilities.Cache.Redis.Secrets;

public record RedisSecrets
{
    [Required]
    public required string ConnectionString { get; set; }
}
