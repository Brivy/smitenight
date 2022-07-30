using SmitenightApp.Domain.Constants.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.PlayerRequests
{
    public record class PlayerStatusRequest(
        string SessionId,
        string PlayerId) : SmiteClientRequest(MethodNameConstants.PlayerStatusMethod, SessionId)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath(PlayerId);
    }
}
