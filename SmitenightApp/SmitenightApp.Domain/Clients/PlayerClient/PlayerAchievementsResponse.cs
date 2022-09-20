namespace SmitenightApp.Domain.Clients.PlayerClient
{
    public record class PlayerAchievementsResponse
    (
        int AssistedKills,
        int CampsCleared,
        int Deaths,
        int DivineSpree,
        int DoubleKills,
        int FireGiantKills,
        int FirstBloods,
        int GodLikeSpree,
        int GoldFuryKills,
        int Id,
        int ImmortalSpree,
        int KillingSpree,
        int MinionKills,
        string Name,
        int PentaKills,
        int PhoenixKills,
        int PlayerKills,
        int QuadraKills,
        int RampageSpree,
        int ShutdownSpree,
        int SiegeJuggernautKills,
        int TowerKills,
        int TripleKills,
        int UnstoppableSpree,
        int WildJuggernautKills,
        object RetMsg
    );
}
