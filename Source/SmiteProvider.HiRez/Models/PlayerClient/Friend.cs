using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.PlayerClient
{
    public record class Friend
    {
        [JsonPropertyName("account_id")] public string? AccountId { get; set; }
        [JsonPropertyName("avatar_url")] public string? AvatarUrl { get; set; }
        [JsonPropertyName("friend_flags")] public string? FriendFlags { get; set; }
        [JsonPropertyName("name")] public string? Name { get; set; }
        [JsonPropertyName("player_id")] public string? PlayerId { get; set; }
        [JsonPropertyName("portal_id")] public string? PortalId { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
        [JsonPropertyName("status")] public string? Status { get; set; }
    }
}
