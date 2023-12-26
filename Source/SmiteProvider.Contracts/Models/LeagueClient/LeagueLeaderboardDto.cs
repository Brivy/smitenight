namespace Smitenight.Providers.SmiteProvider.Contracts.Models.LeagueClient;

public record class LeagueLeaderboardDto
{
    public required int Leaves { get; init; }
    public required int Losses { get; init; }
    public string? Name { get; init; }
    public required int Points { get; init; }
    public required int PrevRank { get; init; }
    public required int Rank { get; init; }
    public required int RankStat { get; init; }
    public string? RankStatConquest { get; init; }
    public string? RankStatJoust { get; init; }
    public required int RankVariance { get; init; }
    public required int Round { get; init; }
    public required int Season { get; init; }
    public required int Tier { get; init; }
    public required int Trend { get; init; }
    public required int Wins { get; init; }
    public required string PlayerId { get; init; }
    public string? RetMsg { get; init; }
}
