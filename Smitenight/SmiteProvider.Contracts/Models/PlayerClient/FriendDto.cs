namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient
{
    public record class FriendDto
    (
        string AccountId,
        string AvatarUrl,
        string FriendFlags,
        string Name,
        string PlayerId,
        string PortalId,
        object RetMsg,
        string Status
    );
}
