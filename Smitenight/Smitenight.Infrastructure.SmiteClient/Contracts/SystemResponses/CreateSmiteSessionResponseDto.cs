using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.SystemResponses
{
    public record class CreateSmiteSessionResponseDto(
        [property: JsonPropertyName("ret_msg")] string RetMsg, 
        [property: JsonPropertyName("session_id")] string SessionId,
        [property: JsonPropertyName("timestamp")] string Timestamp);
}
