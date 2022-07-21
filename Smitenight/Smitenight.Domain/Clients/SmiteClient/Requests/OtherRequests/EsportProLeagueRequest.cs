using Smitenight.Domain.Constants.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.OtherRequests
{
    public record class EsportProLeagueRequest(string SessionId) 
        : SmiteClientRequest(MethodNameConstants.EsportProLeagueMethod, SessionId);
}
