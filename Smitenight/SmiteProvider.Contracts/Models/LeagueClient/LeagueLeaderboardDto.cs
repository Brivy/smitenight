namespace Smitenight.Providers.SmiteProvider.Contracts.Models.LeagueClient
{
    public record class LeagueLeaderboardDto
    (
        int Leaves,
        int Losses,
        string? Name,
        int Points,
        int PrevRank,
        int Rank,
        int RankStat,
        string? RankStatConquest,
        string? RankStatJoust,
        int RankVariance,
        int Round,
        int Season,
        int Tier,
        int Trend,
        int Wins,
        string? PlayerId,
        string? RetMsg
    );
}
