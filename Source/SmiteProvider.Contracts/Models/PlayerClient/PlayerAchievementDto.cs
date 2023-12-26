namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;

public record class PlayerAchievementDto
{
    public required int AssistedKills { get; init; }
    public required int CampsCleared { get; init; }
    public required int Deaths { get; init; }
    public required int DivineSpree { get; init; }
    public required int DoubleKills { get; init; }
    public required int FireGiantKills { get; init; }
    public required int FirstBloods { get; init; }
    public required int GodLikeSpree { get; init; }
    public required int GoldFuryKills { get; init; }
    public required int Id { get; init; }
    public required int ImmortalSpree { get; init; }
    public required int KillingSpree { get; init; }
    public required int MinionKills { get; init; }
    public required string Name { get; init; }
    public required int PentaKills { get; init; }
    public required int PhoenixKills { get; init; }
    public required int PlayerKills { get; init; }
    public required int QuadraKills { get; init; }
    public required int RampageSpree { get; init; }
    public required int ShutdownSpree { get; init; }
    public required int SiegeJuggernautKills { get; init; }
    public required int TowerKills { get; init; }
    public required int TripleKills { get; init; }
    public required int UnstoppableSpree { get; init; }
    public required int WildJuggernautKills { get; init; }
    public string? RetMsg { get; init; }
}
