namespace Smitenight.Domain.Clients.SmiteClient.Responses.RetrievePlayerResponses
{
    public record class PlayerResponseDto
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
        int RankStatConquest,
        int RankStatConquestController,
        int RankStatDuel,
        int RankStatDuelController,
        int RankStatJoust,
        int RankStatJoustController,
        RankedConquestDto RankedConquest,
        RankedConquestControllerDto RankedConquestController,
        RankedDuelDto RankedDuel,
        RankedDuelControllerDto RankedDuelController,
        RankedJoustDto RankedJoust,
        RankedJoustControllerDto RankedJoustController,
        string Region,
        int TeamId,
        string TeamName,
        int TierConquest,
        int TierDuel,
        int TierJoust,
        int TotalAchievements,
        int TotalWorshippers,
        int Wins,
        object HzGamerTag,
        string HzPlayerName,
        object RetMsg
    );

    public record class RankedConquestDto
    (
        int Leaves,
        int Losses,
        string Name,
        int Points,
        int PrevRank,
        int Rank,
        int RankStat,
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

    public record class RankedConquestControllerDto
    (
        int Leaves,
        int Losses,
        string Name,
        int Points,
        int PrevRank,
        int Rank,
        int RankStat,
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

    public record class RankedDuelDto
    (
        int Leaves,
        int Losses,
        string Name,
        int Points,
        int PrevRank,
        int Rank,
        int RankStat,
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

    public record class RankedDuelControllerDto
    (
        int Leaves,
        int Losses,
        string Name,
        int Points,
        int PrevRank,
        int Rank,
        int RankStat,
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

    public record class RankedJoustDto
    (
        int Leaves,
        int Losses,
        string Name,
        int Points,
        int PrevRank,
        int Rank,
        int RankStat,
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

    public record class RankedJoustControllerDto
    (
        int Leaves,
        int Losses,
        string Name,
        int Points,
        int PrevRank,
        int Rank,
        int RankStat,
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