namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;

public record class GodLeaderboardDto
{
    public required string GodId { get; init; }
    public required string Losses { get; init; }
    public required string PlayerId { get; init; }
    public required string PlayerName { get; init; }
    public required string PlayerRanking { get; init; }
    public required string Rank { get; init; }
    public string? RetMsg { get; init; }
    public required string Wins { get; init; }
}
