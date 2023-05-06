using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Contracts.RetrievePlayerResponses
{
    public record class PlayerIdResponseDto
    {
        [JsonPropertyName("player_id")] public int PlayerId { get; set; }
        [JsonPropertyName("portal")] public string? Portal { get; set; }
        [JsonPropertyName("portal_id")] public string? PortalId { get; set; }
        [JsonPropertyName("privacy_flag")] public string? PrivacyFlag { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
    }
}
