using System.ComponentModel.DataAnnotations;

namespace Smitenight.Providers.SmiteProvider.HiRez.Settings;

public record SmiteClientSettings
{
    [Required]
    public required string Url { get; set; }
}
