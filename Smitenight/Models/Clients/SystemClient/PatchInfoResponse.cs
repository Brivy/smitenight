namespace Smitenight.Domain.Models.Clients.SystemClient
{
    public record class PatchInfoResponse(
        object RetMsg,
        string VersionString);
}