namespace Smitenight.Domain.Models.Clients.RetrievePlayerClient
{
    public record class PlayerIdDto(
        int Id,
        string Portal,
        string PortalId,
        string PrivacyFlag,
        object RetMsg
    );
}
