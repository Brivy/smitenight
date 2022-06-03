using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.OtherRequests
{
    public record class EsportProLeagueRequest(
        int DeveloperId,
        string AuthenticationKey,
        string SessionId) : SmiteClientRequest(DeveloperId, AuthenticationKey, MethodNameConstants.EsportProLeagueMethod, SessionId);
}
