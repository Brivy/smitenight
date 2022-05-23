using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.MatchInfoRequests
{
    public record class MatchDetailsBatchRequest(
        int DeveloperId,
        string ResponseType,
        string Signature,
        string SessionId,
        string CurrentDate,
        List<int> MatchIds) : SmiteClientRequest(DeveloperId, MethodNameConstants.MatchDetailsBatchMethod, ResponseType, Signature, SessionId, CurrentDate)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(string.Join(',', MatchIds));
    }
}
