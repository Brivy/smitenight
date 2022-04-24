using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.RetrievePlayerClient;

public record class PlayerId
{
    [JsonPropertyName("player_id")] public int Id { get; set; }
    [JsonPropertyName("portal")] public string? Portal { get; set; }
    [JsonPropertyName("portal_id")] public string? PortalId { get; set; }
    [JsonPropertyName("privacy_flag")] public string? PrivacyFlag { get; set; }
    [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
}
