using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.SystemResponses
{
    public record class PatchInfoResponseDto(
        [property: JsonPropertyName("ret_msg")] object RetMsg,
        [property: JsonPropertyName("version_string")] string VersionString);
}
