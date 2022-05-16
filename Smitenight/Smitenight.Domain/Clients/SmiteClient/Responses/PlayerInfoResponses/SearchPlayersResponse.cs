namespace Smitenight.Domain.Clients.SmiteClient.Responses.PlayerInfoResponses
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
