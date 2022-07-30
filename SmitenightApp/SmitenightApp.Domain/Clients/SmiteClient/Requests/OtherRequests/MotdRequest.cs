using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.OtherRequests
{
    public record class MotdRequest(string SessionId) 
        : SmiteClientRequest(MethodNameConstants.MotdMethod, SessionId);
}
