namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;

public record class PlayerStatusDto
{
    public required int Match { get; init; }
    public required int MatchQueueId { get; init; }
    public required string PersonalStatusMessage { get; init; }
    public string? RetMsg { get; init; }
    public required int Status { get; init; }
    public required string StatusString { get; init; }
}
