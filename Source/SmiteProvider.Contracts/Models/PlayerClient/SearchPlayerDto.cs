namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;

public record class SearchPlayerDto
{
    public string Name { get; init; } = null!;
    public string HzPlayerName { get; init; } = null!;
    public string PlayerId { get; init; } = null!;
    public string PortalId { get; init; } = null!;
    public string PrivacyFlag { get; init; } = null!;
    public string? RetMsg { get; init; }
}
