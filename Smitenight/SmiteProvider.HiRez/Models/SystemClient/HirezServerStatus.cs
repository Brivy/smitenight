using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.SystemClient
{
    public record class HirezServerStatus
    {
        [JsonPropertyName("entry_datetime")] public string? EntryDatetime { get; set; }
        [JsonPropertyName("environment")] public string? Environment { get; set; }
        [JsonPropertyName("limited_access")] public bool LimitedAccess { get; set; }
        [JsonPropertyName("platform")] public string? Platform { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
        [JsonPropertyName("status")] public string? Status { get; set; }
        [JsonPropertyName("version")] public string? Version { get; set; }
    }
}
