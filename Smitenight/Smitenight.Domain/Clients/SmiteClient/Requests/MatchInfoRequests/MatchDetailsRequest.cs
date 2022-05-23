using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.MatchInfoRequests
{
    public record class MatchDetailsRequest(
        int DeveloperId,
        string ResponseType,
        string Signature,
        string SessionId,
        string CurrentDate,
        int MatchId) : SmiteClientRequest(DeveloperId, MethodNameConstants.MatchDetailsMethod, ResponseType, Signature, SessionId, CurrentDate)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(MatchId);
    }
}
