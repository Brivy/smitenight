using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class MatchDetailsBatchRequest(
        string SessionId,
        List<int> MatchIds) : SmiteClientRequest(MethodNameConstants.MatchDetailsBatchMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(string.Join(',', MatchIds));
    }
}
