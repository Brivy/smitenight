namespace Smitenight.Domain.Models.Clients.SystemClient
{
    public record class CreateSmiteSessionResponse(
        string RetMsg,
        string SessionId,
        string Timestamp);
}
