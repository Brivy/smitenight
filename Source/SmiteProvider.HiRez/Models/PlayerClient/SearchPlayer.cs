using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.PlayerClient;

public record class SearchPlayer
{
    [JsonPropertyName("Name")] public string? Name { get; set; }
    [JsonPropertyName("hz_player_name")] public string? HzPlayerName { get; set; }
    [JsonPropertyName("player_id")] public string? PlayerId { get; set; }
    [JsonPropertyName("portal_id")] public string? PortalId { get; set; }
    [JsonPropertyName("privacy_flag")] public string? PrivacyFlag { get; set; }
    [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
}
