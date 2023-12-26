﻿namespace Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient;

public record class MatchDetailsDto
{
    public required int AccountLevel { get; init; }
    public required int ActiveId1 { get; init; }
    public required int ActiveId2 { get; init; }
    public required int ActiveId3 { get; init; }
    public required int ActiveId4 { get; init; }
    public required string ActivePlayerId { get; init; }
    public required int Assists { get; init; }
    public required string Ban1 { get; init; }
    public required string Ban10 { get; init; }
    public required int Ban10Id { get; init; }
    public required string Ban11 { get; init; }
    public required int Ban11Id { get; init; }
    public required string Ban12 { get; init; }
    public required int Ban12Id { get; init; }
    public required int Ban1Id { get; init; }
    public required string Ban2 { get; init; }
    public required int Ban2Id { get; init; }
    public required string Ban3 { get; init; }
    public required int Ban3Id { get; init; }
    public required string Ban4 { get; init; }
    public required int Ban4Id { get; init; }
    public required string Ban5 { get; init; }
    public required int Ban5Id { get; init; }
    public required string Ban6 { get; init; }
    public required int Ban6Id { get; init; }
    public required string Ban7 { get; init; }
    public required int Ban7Id { get; init; }
    public required string Ban8 { get; init; }
    public required int Ban8Id { get; init; }
    public required string Ban9 { get; init; }
    public required int Ban9Id { get; init; }
    public required int CampsCleared { get; init; }
    public required int ConquestLosses { get; init; }
    public required int ConquestPoints { get; init; }
    public required int ConquestTier { get; init; }
    public required int ConquestWins { get; init; }
    public required int DamageBot { get; init; }
    public required int DamageDoneInHand { get; init; }
    public required int DamageDoneMagical { get; init; }
    public required int DamageDonePhysical { get; init; }
    public required int DamageMitigated { get; init; }
    public required int DamagePlayer { get; init; }
    public required int DamageTaken { get; init; }
    public required int DamageTakenMagical { get; init; }
    public required int DamageTakenPhysical { get; init; }
    public required int Deaths { get; init; }
    public required int DistanceTraveled { get; init; }
    public required int DuelLosses { get; init; }
    public required int DuelPoints { get; init; }
    public required int DuelTier { get; init; }
    public required int DuelWins { get; init; }
    public required string EntryDatetime { get; init; }
    public required int FinalMatchLevel { get; init; }
    public required string FirstBanSide { get; init; }
    public required int GodId { get; init; }
    public required int GoldEarned { get; init; }
    public required int GoldPerMinute { get; init; }
    public required int Healing { get; init; }
    public required int HealingBot { get; init; }
    public required int HealingPlayerSelf { get; init; }
    public required int ItemId1 { get; init; }
    public required int ItemId2 { get; init; }
    public required int ItemId3 { get; init; }
    public required int ItemId4 { get; init; }
    public required int ItemId5 { get; init; }
    public required int ItemId6 { get; init; }
    public required string ItemActive1 { get; init; }
    public required string ItemActive2 { get; init; }
    public required string ItemActive3 { get; init; }
    public required string ItemActive4 { get; init; }
    public required string ItemPurch1 { get; init; }
    public required string ItemPurch2 { get; init; }
    public required string ItemPurch3 { get; init; }
    public required string ItemPurch4 { get; init; }
    public required string ItemPurch5 { get; init; }
    public required string ItemPurch6 { get; init; }
    public required int JoustLosses { get; init; }
    public required int JoustPoints { get; init; }
    public required int JoustTier { get; init; }
    public required int JoustWins { get; init; }
    public required int KillingSpree { get; init; }
    public required int KillsBot { get; init; }
    public required int KillsDouble { get; init; }
    public required int KillsFireGiant { get; init; }
    public required int KillsFirstBlood { get; init; }
    public required int KillsGoldFury { get; init; }
    public required int KillsPenta { get; init; }
    public required int KillsPhoenix { get; init; }
    public required int KillsPlayer { get; init; }
    public required int KillsQuadra { get; init; }
    public required int KillsSiegeJuggernaut { get; init; }
    public required int KillsSingle { get; init; }
    public required int KillsTriple { get; init; }
    public required int KillsWildJuggernaut { get; init; }
    public required string MapGame { get; init; }
    public required int MasteryLevel { get; init; }
    public required int Match { get; init; }
    public required int MatchDuration { get; init; }
    public object? MergedPlayers { get; init; }
    public required int Minutes { get; init; }
    public required int MultiKillMax { get; init; }
    public required int ObjectiveAssists { get; init; }
    public required int PartyId { get; init; }
    public required float RankStatConquest { get; init; }
    public required float RankStatDuel { get; init; }
    public required float RankStatJoust { get; init; }
    public required string ReferenceName { get; init; }
    public required string Region { get; init; }
    public required string Role { get; init; }
    public required string Skin { get; init; }
    public required int SkinId { get; init; }
    public required int StructureDamage { get; init; }
    public required int Surrendered { get; init; }
    public required int TaskForce { get; init; }
    public required int Team1Score { get; init; }
    public required int Team2Score { get; init; }
    public required int TeamId { get; init; }
    public required string TeamName { get; init; }
    public required int TimeDeadSeconds { get; init; }
    public required int TimeInMatchSeconds { get; init; }
    public required int TowersDestroyed { get; init; }
    public required int WardsPlaced { get; init; }
    public required string WinStatus { get; init; }
    public required int WinningTaskForce { get; init; }
    public required string HasReplay { get; init; }
    public string? HzGamerTag { get; init; }
    public string? HzPlayerName { get; init; }
    public required int MatchQueueId { get; init; }
    public required string Name { get; init; }
    public required string PlayerId { get; init; }
    public required string PlayerName { get; init; }
    public required string PlayerPortalId { get; init; }
    public required string PlayerPortalUserId { get; init; }
    public string? RetMsg { get; init; }
}
