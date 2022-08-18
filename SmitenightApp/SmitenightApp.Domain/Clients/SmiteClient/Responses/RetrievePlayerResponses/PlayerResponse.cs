namespace SmitenightApp.Domain.Clients.SmiteClient.Responses.RetrievePlayerResponses
{
    public record class PlayerResponse
    (
        int ActivePlayerId,
        string AvatarUrl,
        string CreatedDatetime,
        int HoursPlayed,
        int Id,
        string LastLoginDatetime,
        int Leaves,
        int Level,
        int Losses,
        int MasteryLevel,
        object MergedPlayers,
        int MinutesPlayed,
        string Name,
        string PersonalStatusMessage,
        string Platform,
        float RankStatConquest,
        float RankStatConquestController,
        float RankStatDuel,
        float RankStatDuelController,
        float RankStatJoust,
        float RankStatJoustController,
        RankedConquest RankedConquest,
        RankedConquestController RankedConquestController,
        RankedDuel RankedDuel,
        RankedDuelController RankedDuelController,
        RankedJoust RankedJoust,
        RankedJoustController RankedJoustController,
        string Region,
        int TeamId,
        string TeamName,
        int TierConquest,
        int TierDuel,
        int TierJoust,
        int TotalAchievements,
        int TotalWorshippers,
        int Wins,
        string HzGamerTag,
        string HzPlayerName,
        object RetMsg
    );

    public record class RankedConquest
    (
        int Leaves,
        int Losses,
        string Name,
        int Points,
        int PrevRank,
        int Rank,
        float RankStat,
        object RankStatConquest,
        object RankStatJoust,
        int RankVariance,
        int Round,
        int Season,
        int Tier,
        int Trend,
        int Wins,
        object PlayerId,
        object RetMsg
    );

    public record class RankedConquestController
    (
        int Leaves,
        int Losses,
        string Name,
        int Points,
        int PrevRank,
        int Rank,
        float RankStat,
        object RankStatConquest,
        object RankStatJoust,
        int RankVariance,
        int Round,
        int Season,
        int Tier,
        int Trend,
        int Wins,
        object PlayerId,
        object RetMsg
    );

    public record class RankedDuel
    (
        int Leaves,
        int Losses,
        string Name,
        int Points,
        int PrevRank,
        int Rank,
        float RankStat,
        object RankStatConquest,
        object RankStatJoust,
        int RankVariance,
        int Round,
        int Season,
        int Tier,
        int Trend,
        int Wins,
        object PlayerId,
        object RetMsg
    );

    public record class RankedDuelController
    (
        int Leaves,
        int Losses,
        string Name,
        int Points,
        int PrevRank,
        int Rank,
        float RankStat,
        object RankStatConquest,
        object RankStatJoust,
        int RankVariance,
        int Round,
        int Season,
        int Tier,
        int Trend,
        int Wins,
        object PlayerId,
        object RetMsg
    );

    public record class RankedJoust
    (
        int Leaves,
        int Losses,
        string Name,
        int Points,
        int PrevRank,
        int Rank,
        float RankStat,
        object RankStatConquest,
        object RankStatJoust,
        int RankVariance,
        int Round,
        int Season,
        int Tier,
        int Trend,
        int Wins,
        object PlayerId,
        object RetMsg
    );

    public record class RankedJoustController
    (
        int Leaves,
        int Losses,
        string Name,
        int Points,
        int PrevRank,
        int Rank,
        float RankStat,
        object RankStatConquest,
        object RankStatJoust,
        int RankVariance,
        int Round,
        int Season,
        int Tier,
        int Trend,
        int Wins,
        object PlayerId,
        object RetMsg
    );
}