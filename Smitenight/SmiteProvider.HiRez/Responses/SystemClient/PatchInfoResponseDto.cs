using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Responses.SystemClient
{
    public record class PatchInfoResponseDto
    {
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
        [JsonPropertyName("version_string")] public string? VersionString { get; set; }
    }
}
