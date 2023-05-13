namespace Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient
{
    public record class CreateSmiteSessionDto(
        string RetMsg,
        string SessionId,
        string Timestamp);
}
