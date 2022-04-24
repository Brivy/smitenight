namespace Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient;

public record class MatchDetailsDto
{
    public int AccountLevel { get; init; }
    public int ActiveId1 { get; init; }
    public int ActiveId2 { get; init; }
    public int ActiveId3 { get; init; }
    public int ActiveId4 { get; init; }
    public string ActivePlayerId { get; init; } = null!;
    public int Assists { get; init; }
    public string Ban1 { get; init; } = null!;
    public string Ban10 { get; init; } = null!;
    public int Ban10Id { get; init; }
    public string Ban11 { get; init; } = null!;
    public int Ban11Id { get; init; }
    public string Ban12 { get; init; } = null!;
    public int Ban12Id { get; init; }
    public int Ban1Id { get; init; }
    public string Ban2 { get; init; } = null!;
    public int Ban2Id { get; init; }
    public string Ban3 { get; init; } = null!;
    public int Ban3Id { get; init; }
    public string Ban4 { get; init; } = null!;
    public int Ban4Id { get; init; }
    public string Ban5 { get; init; } = null!;
    public int Ban5Id { get; init; }
    public string Ban6 { get; init; } = null!;
    public int Ban6Id { get; init; }
    public string Ban7 { get; init; } = null!;
    public int Ban7Id { get; init; }
    public string Ban8 { get; init; } = null!;
    public int Ban8Id { get; init; }
    public string Ban9 { get; init; } = null!;
    public int Ban9Id { get; init; }
    public int CampsCleared { get; init; }
    public int ConquestLosses { get; init; }
    public int ConquestPoints { get; init; }
    public int ConquestTier { get; init; }
    public int ConquestWins { get; init; }
    public int DamageBot { get; init; }
    public int DamageDoneInHand { get; init; }
    public int DamageDoneMagical { get; init; }
    public int DamageDonePhysical { get; init; }
    public int DamageMitigated { get; init; }
    public int DamagePlayer { get; init; }
    public int DamageTaken { get; init; }
    public int DamageTakenMagical { get; init; }
    public int DamageTakenPhysical { get; init; }
    public int Deaths { get; init; }
    public int DistanceTraveled { get; init; }
    public int DuelLosses { get; init; }
    public int DuelPoints { get; init; }
    public int DuelTier { get; init; }
    public int DuelWins { get; init; }
    public string EntryDatetime { get; init; } = null!;
    public int FinalMatchLevel { get; init; }
    public string FirstBanSide { get; init; } = null!;
    public int GodId { get; init; }
    public int GoldEarned { get; init; }
    public int GoldPerMinute { get; init; }
    public int Healing { get; init; }
    public int HealingBot { get; init; }
    public int HealingPlayerSelf { get; init; }
    public int ItemId1 { get; init; }
    public int ItemId2 { get; init; }
    public int ItemId3 { get; init; }
    public int ItemId4 { get; init; }
    public int ItemId5 { get; init; }
    public int ItemId6 { get; init; }
    public string ItemActive1 { get; init; } = null!;
    public string ItemActive2 { get; init; } = null!;
    public string ItemActive3 { get; init; } = null!;
    public string ItemActive4 { get; init; } = null!;
    public string ItemPurch1 { get; init; } = null!;
    public string ItemPurch2 { get; init; } = null!;
    public string ItemPurch3 { get; init; } = null!;
    public string ItemPurch4 { get; init; } = null!;
    public string ItemPurch5 { get; init; } = null!;
    public string ItemPurch6 { get; init; } = null!;
    public int JoustLosses { get; init; }
    public int JoustPoints { get; init; }
    public int JoustTier { get; init; }
    public int JoustWins { get; init; }
    public int KillingSpree { get; init; }
    public int KillsBot { get; init; }
    public int KillsDouble { get; init; }
    public int KillsFireGiant { get; init; }
    public int KillsFirstBlood { get; init; }
    public int KillsGoldFury { get; init; }
    public int KillsPenta { get; init; }
    public int KillsPhoenix { get; init; }
    public int KillsPlayer { get; init; }
    public int KillsQuadra { get; init; }
    public int KillsSiegeJuggernaut { get; init; }
    public int KillsSingle { get; init; }
    public int KillsTriple { get; init; }
    public int KillsWildJuggernaut { get; init; }
    public string MapGame { get; init; } = null!;
    public int MasteryLevel { get; init; }
    public int Match { get; init; }
    public int MatchDuration { get; init; }
    public object? MergedPlayers { get; init; }
    public int Minutes { get; init; }
    public int MultiKillMax { get; init; }
    public int ObjectiveAssists { get; init; }
    public int PartyId { get; init; }
    public float RankStatConquest { get; init; }
    public float RankStatDuel { get; init; }
    public float RankStatJoust { get; init; }
    public string ReferenceName { get; init; } = null!;
    public string Region { get; init; } = null!;
    public string Role { get; init; } = null!;
    public string Skin { get; init; } = null!;
    public int SkinId { get; init; }
    public int StructureDamage { get; init; }
    public int Surrendered { get; init; }
    public int TaskForce { get; init; }
    public int Team1Score { get; init; }
    public int Team2Score { get; init; }
    public int TeamId { get; init; }
    public string TeamName { get; init; } = null!;
    public int TimeDeadSeconds { get; init; }
    public int TimeInMatchSeconds { get; init; }
    public int TowersDestroyed { get; init; }
    public int WardsPlaced { get; init; }
    public string WinStatus { get; init; } = null!;
    public int WinningTaskForce { get; init; }
    public string HasReplay { get; init; } = null!;
    public string? HzGamerTag { get; init; }
    public string? HzPlayerName { get; init; }
    public int MatchQueueId { get; init; }
    public string Name { get; init; } = null!;
    public string PlayerId { get; init; } = null!;
    public string PlayerName { get; init; } = null!;
    public string PlayerPortalId { get; init; } = null!;
    public string PlayerPortalUserId { get; init; } = null!;
    public string? RetMsg { get; init; }
}
