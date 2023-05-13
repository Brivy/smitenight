namespace Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient
{
    public record class MatchPlayersDetailsDto
    (
        int AccountGodsPlayed,
        int AccountLevel,
        int GodId,
        int GodLevel,
        string GodName,
        int MasteryLevel,
        int Match,
        string Queue,
        int RankStat,
        int SkinId,
        int Tier,
        string MapGame,
        string PlayerCreated,
        string PlayerId,
        string PlayerName,
        string PlayerRegion,
        object RetMsg,
        int TaskForce,
        int TierLosses,
        int TierPoints,
        int TierWins
    );
}
