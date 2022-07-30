using System.Text.Json.Serialization;

namespace SmitenightApp.Infrastructure.SmiteClient.Contracts.SystemResponses
{
    public record class PatchInfoResponseDto
    {
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
        [JsonPropertyName("version_string")] public string? VersionString { get; set; }
    }
}
