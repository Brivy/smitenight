namespace Smitenight.Providers.SmiteProvider.Contracts.Models.RetrievePlayerClient;

public record class PlayerIdDto
{
    public int PlayerId { get; init; }
    public string Portal { get; init; } = null!;
    public string PortalId { get; init; } = null!;
    public string PrivacyFlag { get; init; } = null!;
    public string? RetMsg { get; init; }
}
