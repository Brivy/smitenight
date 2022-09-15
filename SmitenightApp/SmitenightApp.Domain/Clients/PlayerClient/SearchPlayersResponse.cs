namespace SmitenightApp.Domain.Clients.PlayerClient
{
    public record class SearchPlayersResponse
    (
        string Name,
        string HzPlayerName,
        string PlayerId,
        string PortalId,
        string PrivacyFlag,
        object RetMsg
    );
}
