namespace Smitenight.Providers.SmiteProvider.Contracts.Models.LeagueClient;

public record class LeagueLeaderboardDto
{
    public int Leaves { get; init; }
    public int Losses { get; init; }
    public string? Name { get; init; }
    public int Points { get; init; }
    public int PrevRank { get; init; }
    public int Rank { get; init; }
    public int RankStat { get; init; }
    public string? RankStatConquest { get; init; }
    public string? RankStatJoust { get; init; }
    public int RankVariance { get; init; }
    public int Round { get; init; }
    public int Season { get; init; }
    public int Tier { get; init; }
    public int Trend { get; init; }
    public int Wins { get; init; }
    public string PlayerId { get; init; } = null!;
    public string? RetMsg { get; init; }
}
