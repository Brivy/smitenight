namespace Smitenight.Domain.Models.Clients.GodClient
{
    public record class GodLeaderbordResponse(
        string GodId,
        string Losses,
        string PlayerId,
        string PlayerName,
        string PlayerRanking,
        string Rank,
        object RetMsg,
        string Wins);
}
