using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.MatchRequests
{
    public record class TopMatchesRequest(string SessionId) 
        : SmiteClientRequest(MethodNameConstants.TopMatchesMethod, SessionId);
}
