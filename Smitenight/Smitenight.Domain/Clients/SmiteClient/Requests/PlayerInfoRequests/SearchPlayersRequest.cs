using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.PlayerInfoRequests
{
    public record class SearchPlayersRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        string PlayerId) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.SearchPlayersMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
