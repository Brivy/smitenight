using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.PlayerInfoResponses
{
    public record class PlayerStatusResponseDto
    (
        [property: JsonPropertyName("Match")] int Match,
        [property: JsonPropertyName("match_queue_id")] int MatchQueueId,
        [property: JsonPropertyName("personal_status_message")] string PersonalStatusMessage,
        [property: JsonPropertyName("ret_msg")] object RetMsg,
        [property: JsonPropertyName("status")] int Status,
        [property: JsonPropertyName("status_string")] string StatusString
    );
}
