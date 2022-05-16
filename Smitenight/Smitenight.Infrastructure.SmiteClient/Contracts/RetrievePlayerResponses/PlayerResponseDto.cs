using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.RetrievePlayerResponses
{
    public record class PlayerResponseDto
    (
        [property: JsonPropertyName("ActivePlayerId")] int ActivePlayerId,
        [property: JsonPropertyName("Avatar_URL")] string AvatarUrl,
        [property: JsonPropertyName("Created_Datetime")] string CreatedDatetime,
        [property: JsonPropertyName("HoursPlayed")] int HoursPlayed,
        [property: JsonPropertyName("Id")] int Id,
        [property: JsonPropertyName("Last_Login_Datetime")] string LastLoginDatetime,
        [property: JsonPropertyName("Leaves")] int Leaves,
        [property: JsonPropertyName("Level")] int Level,
        [property: JsonPropertyName("Losses")] int Losses,
        [property: JsonPropertyName("MasteryLevel")] int MasteryLevel,
        [property: JsonPropertyName("MergedPlayers")] object MergedPlayers,
        [property: JsonPropertyName("MinutesPlayed")] int MinutesPlayed,
        [property: JsonPropertyName("Name")] string Name,
        [property: JsonPropertyName("Personal_Status_Message")] string PersonalStatusMessage,
        [property: JsonPropertyName("Platform")] string Platform,
        [property: JsonPropertyName("Rank_Stat_Conquest")] int RankStatConquest,
        [property: JsonPropertyName("Rank_Stat_Conquest_Controller")] int RankStatConquestController,
        [property: JsonPropertyName("Rank_Stat_Duel")] int RankStatDuel,
        [property: JsonPropertyName("Rank_Stat_Duel_Controller")] int RankStatDuelController,
        [property: JsonPropertyName("Rank_Stat_Joust")] int RankStatJoust,
        [property: JsonPropertyName("Rank_Stat_Joust_Controller")] int RankStatJoustController,
        [property: JsonPropertyName("RankedConquest")] RankedConquestDto RankedConquest,
        [property: JsonPropertyName("RankedConquestController")] RankedConquestControllerDto RankedConquestController,
        [property: JsonPropertyName("RankedDuel")] RankedDuelDto RankedDuel,
        [property: JsonPropertyName("RankedDuelController")] RankedDuelControllerDto RankedDuelController,
        [property: JsonPropertyName("RankedJoust")] RankedJoustDto RankedJoust,
        [property: JsonPropertyName("RankedJoustController")] RankedJoustControllerDto RankedJoustController,
        [property: JsonPropertyName("Region")] string Region,
        [property: JsonPropertyName("TeamId")] int TeamId,
        [property: JsonPropertyName("Team_Name")] string TeamName,
        [property: JsonPropertyName("Tier_Conquest")] int TierConquest,
        [property: JsonPropertyName("Tier_Duel")] int TierDuel,
        [property: JsonPropertyName("Tier_Joust")] int TierJoust,
        [property: JsonPropertyName("Total_Achievements")] int TotalAchievements,
        [property: JsonPropertyName("Total_Worshippers")] int TotalWorshippers,
        [property: JsonPropertyName("Wins")] int Wins,
        [property: JsonPropertyName("hz_gamer_tag")] object HzGamerTag,
        [property: JsonPropertyName("hz_player_name")] string HzPlayerName,
        [property: JsonPropertyName("ret_msg")] object RetMsg
    );

    public record class RankedConquestDto
    (
        [property: JsonPropertyName("Leaves")] int Leaves,
        [property: JsonPropertyName("Losses")] int Losses,
        [property: JsonPropertyName("Name")] string Name,
        [property: JsonPropertyName("Points")] int Points,
        [property: JsonPropertyName("PrevRank")] int PrevRank,
        [property: JsonPropertyName("Rank")] int Rank,
        [property: JsonPropertyName("Rank_Stat")] int RankStat,
        [property: JsonPropertyName("Rank_Stat_Conquest")] object RankStatConquest,
        [property: JsonPropertyName("Rank_Stat_Joust")] object RankStatJoust,
        [property: JsonPropertyName("Rank_Variance")] int RankVariance,
        [property: JsonPropertyName("Round")] int Round,
        [property: JsonPropertyName("Season")] int Season,
        [property: JsonPropertyName("Tier")] int Tier,
        [property: JsonPropertyName("Trend")] int Trend,
        [property: JsonPropertyName("Wins")] int Wins,
        [property: JsonPropertyName("player_id")] object PlayerId,
        [property: JsonPropertyName("ret_msg")] object RetMsg
    );

    public record class RankedConquestControllerDto
    (
        [property: JsonPropertyName("Leaves")] int Leaves,
        [property: JsonPropertyName("Losses")] int Losses,
        [property: JsonPropertyName("Name")] string Name,
        [property: JsonPropertyName("Points")] int Points,
        [property: JsonPropertyName("PrevRank")] int PrevRank,
        [property: JsonPropertyName("Rank")] int Rank,
        [property: JsonPropertyName("Rank_Stat")] int RankStat,
        [property: JsonPropertyName("Rank_Stat_Conquest")] object RankStatConquest,
        [property: JsonPropertyName("Rank_Stat_Joust")] object RankStatJoust,
        [property: JsonPropertyName("Rank_Variance")] int RankVariance,
        [property: JsonPropertyName("Round")] int Round,
        [property: JsonPropertyName("Season")] int Season,
        [property: JsonPropertyName("Tier")] int Tier,
        [property: JsonPropertyName("Trend")] int Trend,
        [property: JsonPropertyName("Wins")] int Wins,
        [property: JsonPropertyName("player_id")] object PlayerId,
        [property: JsonPropertyName("ret_msg")] object RetMsg
    );

    public record class RankedDuelDto
    (
        [property: JsonPropertyName("Leaves")] int Leaves,
        [property: JsonPropertyName("Losses")] int Losses,
        [property: JsonPropertyName("Name")] string Name,
        [property: JsonPropertyName("Points")] int Points,
        [property: JsonPropertyName("PrevRank")] int PrevRank,
        [property: JsonPropertyName("Rank")] int Rank,
        [property: JsonPropertyName("Rank_Stat")] int RankStat,
        [property: JsonPropertyName("Rank_Stat_Conquest")] object RankStatConquest,
        [property: JsonPropertyName("Rank_Stat_Joust")] object RankStatJoust,
        [property: JsonPropertyName("Rank_Variance")] int RankVariance,
        [property: JsonPropertyName("Round")] int Round,
        [property: JsonPropertyName("Season")] int Season,
        [property: JsonPropertyName("Tier")] int Tier,
        [property: JsonPropertyName("Trend")] int Trend,
        [property: JsonPropertyName("Wins")] int Wins,
        [property: JsonPropertyName("player_id")] object PlayerId,
        [property: JsonPropertyName("ret_msg")] object RetMsg
    );

    public record class RankedDuelControllerDto
    (
        [property: JsonPropertyName("Leaves")] int Leaves,
        [property: JsonPropertyName("Losses")] int Losses,
        [property: JsonPropertyName("Name")] string Name,
        [property: JsonPropertyName("Points")] int Points,
        [property: JsonPropertyName("PrevRank")] int PrevRank,
        [property: JsonPropertyName("Rank")] int Rank,
        [property: JsonPropertyName("Rank_Stat")] int RankStat,
        [property: JsonPropertyName("Rank_Stat_Conquest")] object RankStatConquest,
        [property: JsonPropertyName("Rank_Stat_Joust")] object RankStatJoust,
        [property: JsonPropertyName("Rank_Variance")] int RankVariance,
        [property: JsonPropertyName("Round")] int Round,
        [property: JsonPropertyName("Season")] int Season,
        [property: JsonPropertyName("Tier")] int Tier,
        [property: JsonPropertyName("Trend")] int Trend,
        [property: JsonPropertyName("Wins")] int Wins,
        [property: JsonPropertyName("player_id")] object PlayerId,
        [property: JsonPropertyName("ret_msg")] object RetMsg
    );

    public record class RankedJoustDto
    (
        [property: JsonPropertyName("Leaves")] int Leaves,
        [property: JsonPropertyName("Losses")] int Losses,
        [property: JsonPropertyName("Name")] string Name,
        [property: JsonPropertyName("Points")] int Points,
        [property: JsonPropertyName("PrevRank")] int PrevRank,
        [property: JsonPropertyName("Rank")] int Rank,
        [property: JsonPropertyName("Rank_Stat")] int RankStat,
        [property: JsonPropertyName("Rank_Stat_Conquest")] object RankStatConquest,
        [property: JsonPropertyName("Rank_Stat_Joust")] object RankStatJoust,
        [property: JsonPropertyName("Rank_Variance")] int RankVariance,
        [property: JsonPropertyName("Round")] int Round,
        [property: JsonPropertyName("Season")] int Season,
        [property: JsonPropertyName("Tier")] int Tier,
        [property: JsonPropertyName("Trend")] int Trend,
        [property: JsonPropertyName("Wins")] int Wins,
        [property: JsonPropertyName("player_id")] object PlayerId,
        [property: JsonPropertyName("ret_msg")] object RetMsg
    );

    public record class RankedJoustControllerDto
    (
        [property: JsonPropertyName("Leaves")] int Leaves,
        [property: JsonPropertyName("Losses")] int Losses,
        [property: JsonPropertyName("Name")] string Name,
        [property: JsonPropertyName("Points")] int Points,
        [property: JsonPropertyName("PrevRank")] int PrevRank,
        [property: JsonPropertyName("Rank")] int Rank,
        [property: JsonPropertyName("Rank_Stat")] int RankStat,
        [property: JsonPropertyName("Rank_Stat_Conquest")] object RankStatConquest,
        [property: JsonPropertyName("Rank_Stat_Joust")] object RankStatJoust,
        [property: JsonPropertyName("Rank_Variance")] int RankVariance,
        [property: JsonPropertyName("Round")] int Round,
        [property: JsonPropertyName("Season")] int Season,
        [property: JsonPropertyName("Tier")] int Tier,
        [property: JsonPropertyName("Trend")] int Trend,
        [property: JsonPropertyName("Wins")] int Wins,
        [property: JsonPropertyName("player_id")] object PlayerId,
        [property: JsonPropertyName("ret_msg")] object RetMsg
    );
}