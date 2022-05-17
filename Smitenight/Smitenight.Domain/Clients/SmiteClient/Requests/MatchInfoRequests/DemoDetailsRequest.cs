using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.MatchInfoRequests
{
    public record class DemoDetailsRequest(
        int DeveloperId,
        string ResponseType,
        string Signature,
        string SessionId,
        string CurrentDate,
        int MatchId) : SmiteClientRequest(DeveloperId, MethodNameConstants.DemoDetailsMethod, ResponseType, Signature, SessionId, CurrentDate);
}
