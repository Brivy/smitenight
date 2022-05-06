namespace Smitenight.Domain.Clients.SmiteClient.Responses.SystemResponses
{
    public record class CreateSmiteSessionResponse(
        string RetMsg,
        string SessionId, 
        string Timestamp);
}
