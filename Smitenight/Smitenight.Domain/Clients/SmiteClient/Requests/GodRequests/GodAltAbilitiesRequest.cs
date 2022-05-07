namespace Smitenight.Domain.Clients.SmiteClient.Requests.GodRequests
{
    public record class GodAltAbilitiesRequest(
        int DeveloperId,
        string MethodName,
        string ResponseType,
        string Signature,
        string SessionId,
        string CurrentDate) : SmiteClientRequest(DeveloperId, MethodName, ResponseType, Signature, SessionId, CurrentDate);
}
