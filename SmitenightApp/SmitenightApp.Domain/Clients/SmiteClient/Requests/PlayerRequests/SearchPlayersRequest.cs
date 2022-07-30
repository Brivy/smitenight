using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class SearchPlayersRequest(
        string SessionId,
        string PlayerId) : SmiteClientRequest(MethodNameConstants.SearchPlayersMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
