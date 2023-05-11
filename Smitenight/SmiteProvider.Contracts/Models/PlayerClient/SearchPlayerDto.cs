namespace Smitenight.Domain.Models.Clients.PlayerClient
{
    public record class SearchPlayerDto
    (
        string Name,
        string HzPlayerName,
        string PlayerId,
        string PortalId,
        string PrivacyFlag,
        object RetMsg
    );
}
