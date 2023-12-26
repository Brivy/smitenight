using System.ComponentModel.DataAnnotations;

namespace Smitenight.Utilities.Cache.Redis.Settings;

internal record RedisSettings
{
    [Required]
    public required string EnvironmentPrefix { get; init; }

    [Required]
    public required string InstanceName { get; init; }
}
