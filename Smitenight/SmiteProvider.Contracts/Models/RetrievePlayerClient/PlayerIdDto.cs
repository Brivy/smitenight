namespace Smitenight.Providers.SmiteProvider.Contracts.Models.RetrievePlayerClient
{
    public record class PlayerIdDto(
        int PlayerId,
        string Portal,
        string PortalId,
        string PrivacyFlag,
        object RetMsg
    );
}
