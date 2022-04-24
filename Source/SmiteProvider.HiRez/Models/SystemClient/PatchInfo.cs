using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.SystemClient;

public record class PatchInfo
{
    [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
    [JsonPropertyName("version_string")] public string? VersionString { get; set; }
}
