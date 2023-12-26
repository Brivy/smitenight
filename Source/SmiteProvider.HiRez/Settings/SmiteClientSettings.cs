using System.ComponentModel.DataAnnotations;

namespace Smitenight.Providers.SmiteProvider.HiRez.Settings;

internal record SmiteClientSettings
{
    [Required]
    public required string Url { get; init; }
}
