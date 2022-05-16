using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.PlayerInfoResponses
{
    public record class FriendsResponseDto
    (
        [property: JsonPropertyName("account_id")] string AccountId,
        [property: JsonPropertyName("avatar_url")] string AvatarUrl,
        [property: JsonPropertyName("friend_flags")] string FriendFlags,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("player_id")] string PlayerId,
        [property: JsonPropertyName("portal_id")] string PortalId,
        [property: JsonPropertyName("ret_msg")] object RetMsg,
        [property: JsonPropertyName("status")] string Status
    );
}
