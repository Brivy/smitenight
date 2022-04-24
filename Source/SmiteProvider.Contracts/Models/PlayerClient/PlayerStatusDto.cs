namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;

public record class PlayerStatusDto
{
    public int Match { get; init; }
    public int MatchQueueId { get; init; }
    public string PersonalStatusMessage { get; init; } = null!;
    public string? RetMsg { get; init; }
    public int Status { get; init; }
    public string StatusString { get; init; } = null!;
}
