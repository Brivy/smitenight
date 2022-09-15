namespace SmitenightApp.Domain.Clients.SystemClient
{
    public record class PatchInfoResponse(
        object RetMsg,
        string VersionString);
}