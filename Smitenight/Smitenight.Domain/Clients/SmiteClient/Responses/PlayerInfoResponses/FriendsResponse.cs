namespace Smitenight.Domain.Clients.SmiteClient.Responses.PlayerInfoResponses
{
    public record class FriendsResponse
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
