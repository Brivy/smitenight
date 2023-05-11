namespace Smitenight.Domain.Models.Clients.SystemClient
{
    public record class CreateSmiteSessionDto(
        string RetMsg,
        string SessionId,
        string Timestamp);
}
