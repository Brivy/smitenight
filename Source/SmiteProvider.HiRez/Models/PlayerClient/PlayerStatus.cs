using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.PlayerClient
{
    public record class PlayerStatus
    {
        [JsonPropertyName("Match")] public int Match { get; set; }
        [JsonPropertyName("match_queue_id")] public int MatchQueueId { get; set; }
        [JsonPropertyName("personal_status_message")] public string? PersonalStatusMessage { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
        [JsonPropertyName("status")] public int Status { get; set; }
        [JsonPropertyName("status_string")] public string? StatusString { get; set; }
    }
}
