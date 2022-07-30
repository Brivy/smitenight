namespace SmitenightApp.Domain.Clients.SmiteClient.Responses.PlayerResponses
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
