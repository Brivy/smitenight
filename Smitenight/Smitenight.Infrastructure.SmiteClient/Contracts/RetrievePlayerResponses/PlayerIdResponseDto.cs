using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.RetrievePlayerResponses
{
    public record class PlayerIdResponseDto(
        [property: JsonPropertyName("player_id")] int PlayerId,
        [property: JsonPropertyName("portal")] string Portal,
        [property: JsonPropertyName("portal_id")] string PortalId,
        [property: JsonPropertyName("privacy_flag")] string PrivacyFlag,
        [property: JsonPropertyName("ret_msg")] object RetMsg
    );
}
