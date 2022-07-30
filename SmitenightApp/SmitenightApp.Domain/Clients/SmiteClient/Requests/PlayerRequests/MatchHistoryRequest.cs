using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class MatchHistoryRequest(
        string SessionId,
        string PlayerId) : SmiteClientRequest(MethodNameConstants.MatchHistoryMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
