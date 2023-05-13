namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient
{
    public record class SearchPlayerDto
    (
        string Name,
        string HzPlayerName,
        string PlayerId,
        string PortalId,
        string PrivacyFlag,
        object RetMsg
    );
}
