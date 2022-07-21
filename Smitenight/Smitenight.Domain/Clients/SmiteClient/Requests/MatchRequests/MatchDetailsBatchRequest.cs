using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class MatchDetailsBatchRequest(
        string SessionId,
        List<int> MatchIds) : SmiteClientRequest(MethodNameConstants.MatchDetailsBatchMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(string.Join(',', MatchIds));
    }
}
