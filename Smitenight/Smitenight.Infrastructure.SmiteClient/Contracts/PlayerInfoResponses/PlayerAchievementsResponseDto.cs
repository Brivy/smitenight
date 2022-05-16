using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.PlayerInfoResponses
{
    public record class PlayerAchievementsResponseDto
    (
        [property: JsonPropertyName("AssistedKills")] int AssistedKills,
        [property: JsonPropertyName("CampsCleared")] int CampsCleared,
        [property: JsonPropertyName("Deaths")] int Deaths,
        [property: JsonPropertyName("DivineSpree")] int DivineSpree,
        [property: JsonPropertyName("DoubleKills")] int DoubleKills,
        [property: JsonPropertyName("FireGiantKills")] int FireGiantKills,
        [property: JsonPropertyName("FirstBloods")] int FirstBloods,
        [property: JsonPropertyName("GodLikeSpree")] int GodLikeSpree,
        [property: JsonPropertyName("GoldFuryKills")] int GoldFuryKills,
        [property: JsonPropertyName("Id")] int Id,
        [property: JsonPropertyName("ImmortalSpree")] int ImmortalSpree,
        [property: JsonPropertyName("KillingSpree")] int KillingSpree,
        [property: JsonPropertyName("MinionKills")] int MinionKills,
        [property: JsonPropertyName("Name")] string Name,
        [property: JsonPropertyName("PentaKills")] int PentaKills,
        [property: JsonPropertyName("PhoenixKills")] int PhoenixKills,
        [property: JsonPropertyName("PlayerKills")] int PlayerKills,
        [property: JsonPropertyName("QuadraKills")] int QuadraKills,
        [property: JsonPropertyName("RampageSpree")] int RampageSpree,
        [property: JsonPropertyName("ShutdownSpree")] int ShutdownSpree,
        [property: JsonPropertyName("SiegeJuggernautKills")] int SiegeJuggernautKills,
        [property: JsonPropertyName("TowerKills")] int TowerKills,
        [property: JsonPropertyName("TripleKills")] int TripleKills,
        [property: JsonPropertyName("UnstoppableSpree")] int UnstoppableSpree,
        [property: JsonPropertyName("WildJuggernautKills")] int WildJuggernautKills,
        [property: JsonPropertyName("ret_msg")] object RetMsg
    );
}
