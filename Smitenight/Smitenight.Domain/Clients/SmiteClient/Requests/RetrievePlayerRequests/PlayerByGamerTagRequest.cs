namespace Smitenight.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests
{
    public record class PlayerByGamerTagRequest(
        int DeveloperId,
        string MethodName,
        string ResponseType,
        string Signature,
        string SessionId,
        string CurrentDate,
        string PortalId,
        string GamerTag) : SmiteClientRequest(DeveloperId, MethodName, ResponseType, Signature, SessionId, CurrentDate);
}
