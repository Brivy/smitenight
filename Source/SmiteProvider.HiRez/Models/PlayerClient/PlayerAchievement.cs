using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.PlayerClient;

public record class PlayerAchievement
{
    [JsonPropertyName("AssistedKills")] public int AssistedKills { get; set; }
    [JsonPropertyName("CampsCleared")] public int CampsCleared { get; set; }
    [JsonPropertyName("Deaths")] public int Deaths { get; set; }
    [JsonPropertyName("DivineSpree")] public int DivineSpree { get; set; }
    [JsonPropertyName("DoubleKills")] public int DoubleKills { get; set; }
    [JsonPropertyName("FireGiantKills")] public int FireGiantKills { get; set; }
    [JsonPropertyName("FirstBloods")] public int FirstBloods { get; set; }
    [JsonPropertyName("GodLikeSpree")] public int GodLikeSpree { get; set; }
    [JsonPropertyName("GoldFuryKills")] public int GoldFuryKills { get; set; }
    [JsonPropertyName("Id")] public int Id { get; set; }
    [JsonPropertyName("ImmortalSpree")] public int ImmortalSpree { get; set; }
    [JsonPropertyName("KillingSpree")] public int KillingSpree { get; set; }
    [JsonPropertyName("MinionKills")] public int MinionKills { get; set; }
    [JsonPropertyName("Name")] public string? Name { get; set; }
    [JsonPropertyName("PentaKills")] public int PentaKills { get; set; }
    [JsonPropertyName("PhoenixKills")] public int PhoenixKills { get; set; }
    [JsonPropertyName("PlayerKills")] public int PlayerKills { get; set; }
    [JsonPropertyName("QuadraKills")] public int QuadraKills { get; set; }
    [JsonPropertyName("RampageSpree")] public int RampageSpree { get; set; }
    [JsonPropertyName("ShutdownSpree")] public int ShutdownSpree { get; set; }
    [JsonPropertyName("SiegeJuggernautKills")] public int SiegeJuggernautKills { get; set; }
    [JsonPropertyName("TowerKills")] public int TowerKills { get; set; }
    [JsonPropertyName("TripleKills")] public int TripleKills { get; set; }
    [JsonPropertyName("UnstoppableSpree")] public int UnstoppableSpree { get; set; }
    [JsonPropertyName("WildJuggernautKills")] public int WildJuggernautKills { get; set; }
    [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
}
