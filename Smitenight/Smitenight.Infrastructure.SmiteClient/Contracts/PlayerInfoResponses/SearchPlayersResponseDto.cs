using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.PlayerInfoResponses
{
    public record class SearchPlayersResponseDto
    (
        [property: JsonPropertyName("Name")] string Name,
        [property: JsonPropertyName("hz_player_name")] string HzPlayerName,
        [property: JsonPropertyName("player_id")] string PlayerId,
        [property: JsonPropertyName("portal_id")] string PortalId,
        [property: JsonPropertyName("privacy_flag")] string PrivacyFlag,
        [property: JsonPropertyName("ret_msg")] object RetMsg
    );
}
