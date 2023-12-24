namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;

public record class PlayerAchievementDto
{
    public int AssistedKills { get; init; }
    public int CampsCleared { get; init; }
    public int Deaths { get; init; }
    public int DivineSpree { get; init; }
    public int DoubleKills { get; init; }
    public int FireGiantKills { get; init; }
    public int FirstBloods { get; init; }
    public int GodLikeSpree { get; init; }
    public int GoldFuryKills { get; init; }
    public int Id { get; init; }
    public int ImmortalSpree { get; init; }
    public int KillingSpree { get; init; }
    public int MinionKills { get; init; }
    public string Name { get; init; } = null!;
    public int PentaKills { get; init; }
    public int PhoenixKills { get; init; }
    public int PlayerKills { get; init; }
    public int QuadraKills { get; init; }
    public int RampageSpree { get; init; }
    public int ShutdownSpree { get; init; }
    public int SiegeJuggernautKills { get; init; }
    public int TowerKills { get; init; }
    public int TripleKills { get; init; }
    public int UnstoppableSpree { get; init; }
    public int WildJuggernautKills { get; init; }
    public string? RetMsg { get; init; }
}
