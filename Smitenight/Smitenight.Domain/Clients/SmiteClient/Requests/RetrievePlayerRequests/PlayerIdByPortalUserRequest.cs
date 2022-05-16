using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
{
    public record class PlayerIdByPortalUserRequest(
        int DeveloperId,
        string MethodName,
        string ResponseType,
        string Signature,
        string SessionId,
        string CurrentDate,
        PortalTypeEnum PortalType,
        string PortalUserId) : SmiteClientRequest(DeveloperId, MethodName, ResponseType, Signature, SessionId, CurrentDate);
}
