using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.MatchInfoRequests
{
    public record class MatchDetailsBatchRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId,
        List<int> MatchIds) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.MatchDetailsBatchMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(string.Join(',', MatchIds));
    }
}
