using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class MatchHistoryRequest(
        string PlayerId) : SmiteClientRequest(MethodNameConstants.MatchHistoryMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
