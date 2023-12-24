using System.ComponentModel.DataAnnotations;

namespace Smitenight.Utilities.Cache.Redis.Settings
{
    public record RedisSettings
    {
        [Required]
        public required string EnvironmentPrefix { get; set; }

        [Required]
        public required string InstanceName { get; set; }
    }
}
