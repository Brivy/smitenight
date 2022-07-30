using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.SystemRequests
{
    public record class PatchInfoRequest(string SessionId) 
        : SmiteClientRequest(MethodNameConstants.PatchInfoMethod, SessionId);
}
