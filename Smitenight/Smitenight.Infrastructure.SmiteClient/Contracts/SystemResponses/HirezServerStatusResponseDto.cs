using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.SystemResponses
{ 
    public record class HirezServerStatusResponseDto(
        [property: JsonPropertyName("entry_datetime")] string EntryDatetime,
        [property: JsonPropertyName("environment")] string Environment,
        [property: JsonPropertyName("limited_access")] bool LimitedAccess,
        [property: JsonPropertyName("platform")] string Platform,
        [property: JsonPropertyName("ret_msg")] object RetMsg,
        [property: JsonPropertyName("status")] string Status,
        [property: JsonPropertyName("version")] string Version);
}
