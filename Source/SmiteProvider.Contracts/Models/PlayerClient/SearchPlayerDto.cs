namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;

public record class SearchPlayerDto
{
    public required string Name { get; init; }
    public required string HzPlayerName { get; init; }
    public required string PlayerId { get; init; }
    public required string PortalId { get; init; }
    public required string PrivacyFlag { get; init; }
    public string? RetMsg { get; init; }
}
