using System.ComponentModel.DataAnnotations;

namespace Smitenight.Providers.SmiteProvider.HiRez.Secrets;

internal record SmiteClientSecrets
{
    [Required]
    public required int DeveloperId { get; init; }

    [Required]
    public required string AuthenticationKey { get; init; }
}
