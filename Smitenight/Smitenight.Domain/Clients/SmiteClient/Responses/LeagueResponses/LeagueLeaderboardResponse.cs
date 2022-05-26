namespace Smitenight.Domain.Clients.SmiteClient.Responses.LeagueResponses
{
    public record class LeagueLeaderboardResponse
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
