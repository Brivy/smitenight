namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient
{
    public record class GodLeaderbordDto(
        string GodId,
        string Losses,
        string PlayerId,
        string PlayerName,
        string PlayerRanking,
        string Rank,
        object RetMsg,
        string Wins);
}
