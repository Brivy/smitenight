namespace Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient;

public record class MatchPlayerDetailsDto
{
    public required int AccountGodsPlayed { get; init; }
    public required int AccountLevel { get; init; }
    public required int GodId { get; init; }
    public required int GodLevel { get; init; }
    public required string GodName { get; init; }
    public required int MasteryLevel { get; init; }
    public required int Match { get; init; }
    public required string Queue { get; init; }
    public required int RankStat { get; init; }
    public required int SkinId { get; init; }
    public required int Tier { get; init; }
    public required string MapGame { get; init; }
    public required string PlayerCreated { get; init; }
    public required string PlayerId { get; init; }
    public required string PlayerName { get; init; }
    public required string PlayerRegion { get; init; }
    public string? RetMsg { get; init; }
    public required int TaskForce { get; init; }
    public required int TierLosses { get; init; }
    public required int TierPoints { get; init; }
    public required int TierWins { get; init; }
}
