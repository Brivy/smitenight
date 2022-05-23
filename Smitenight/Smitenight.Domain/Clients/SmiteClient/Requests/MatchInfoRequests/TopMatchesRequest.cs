using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.MatchInfoRequests
{
    public record class TopMatchesRequest(
        int DeveloperId,
        string ResponseType,
        string Signature,
        string SessionId,
        string CurrentDate) : SmiteClientRequest(DeveloperId, MethodNameConstants.TopMatchesMethod, ResponseType, Signature, SessionId, CurrentDate);
}
