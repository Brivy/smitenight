namespace Smitenight.Domain.Models.Clients.PlayerClient
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
