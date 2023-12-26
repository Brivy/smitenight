namespace Smitenight.Providers.SmiteProvider.Contracts.Models.RetrievePlayerClient;

public record class RankedDetailsDto
{
    public required int Leaves { get; init; }
    public required int Losses { get; init; }
    public required string Name { get; init; }
    public required int Points { get; init; }
    public required int PrevRank { get; init; }
    public required int Rank { get; init; }
    public required float RankStat { get; init; }
    public int? RankStatConquest { get; init; }
    public int? RankStatJoust { get; init; }
    public required int RankVariance { get; init; }
    public required int Round { get; init; }
    public required int Season { get; init; }
    public required int Tier { get; init; }
    public required int Trend { get; init; }
    public required int Wins { get; init; }
    public required int PlayerId { get; init; }
    public string? RetMsg { get; init; }
}
