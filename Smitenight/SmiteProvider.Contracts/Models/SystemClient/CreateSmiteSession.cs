namespace Smitenight.Domain.Models.Clients.SystemClient
{
    public record class CreateSmiteSession(
        string RetMsg,
        string SessionId,
        string Timestamp);
}
