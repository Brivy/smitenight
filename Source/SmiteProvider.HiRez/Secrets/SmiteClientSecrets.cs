using System.ComponentModel.DataAnnotations;

namespace Smitenight.Providers.SmiteProvider.HiRez.Secrets;

public record SmiteClientSecrets
{
    [Required]
    public required int DeveloperId { get; set; }

    [Required]
    public required string AuthenticationKey { get; set; }
}
