namespace Smitenight.Providers.SmiteProvider.Contracts.Models.RetrievePlayerClient;

public record class PlayerIdDto
{
    public required int PlayerId { get; init; }
    public required string Portal { get; init; }
    public required string PortalId { get; init; }
    public required string PrivacyFlag { get; init; }
    public string? RetMsg { get; init; }
}
