namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;

public record class QueueStatsDto
{
    public required int Assists { get; init; }
    public required int Deaths { get; init; }
    public required string God { get; init; }
    public required int GodId { get; init; }
    public required int Gold { get; init; }
    public required int Kills { get; init; }
    public required string LastPlayed { get; init; }
    public required int Losses { get; init; }
    public required int Matches { get; init; }
    public required int Minutes { get; init; }
    public required string Queue { get; init; }
    public required int Wins { get; init; }
    public required string PlayerId { get; init; }
    public string? RetMsg { get; init; }
}
