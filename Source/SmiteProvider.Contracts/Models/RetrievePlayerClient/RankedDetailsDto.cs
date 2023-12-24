namespace Smitenight.Providers.SmiteProvider.Contracts.Models.RetrievePlayerClient;

public record class RankedDetailsDto
{
    public int Leaves { get; init; }
    public int Losses { get; init; }
    public string Name { get; init; } = null!;
    public int Points { get; init; }
    public int PrevRank { get; init; }
    public int Rank { get; init; }
    public float RankStat { get; init; }
    public int? RankStatConquest { get; init; }
    public int? RankStatJoust { get; init; }
    public int RankVariance { get; init; }
    public int Round { get; init; }
    public int Season { get; init; }
    public int Tier { get; init; }
    public int Trend { get; init; }
    public int Wins { get; init; }
    public int PlayerId { get; init; }
    public string? RetMsg { get; init; }
}
