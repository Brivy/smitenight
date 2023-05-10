using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Responses.SystemClient
{
    public record class CreateSmiteSessionResponseDto
    {
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
        [JsonPropertyName("session_id")] public string? SessionId { get; set; }
        [JsonPropertyName("timestamp")] public string? Timestamp { get; set; }
    }
}
