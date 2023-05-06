namespace Smitenight.Domain.Models.Clients.RetrievePlayerClient
{
    public record class PlayerIdResponse(
        int PlayerId,
        string Portal,
        string PortalId,
        string PrivacyFlag,
        object RetMsg
    );
}
