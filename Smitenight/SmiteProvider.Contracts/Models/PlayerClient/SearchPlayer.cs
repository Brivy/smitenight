namespace Smitenight.Domain.Models.Clients.PlayerClient
{
    public record class SearchPlayer
    (
        string Name,
        string HzPlayerName,
        string PlayerId,
        string PortalId,
        string PrivacyFlag,
        object RetMsg
    );
}
