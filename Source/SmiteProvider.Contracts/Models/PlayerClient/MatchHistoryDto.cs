namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient
{
    public record class MatchHistoryDto
    {
        public int ActiveId1 { get; init; }
        public int ActiveId2 { get; init; }
        public string Active1 { get; init; } = null!;
        public string Active2 { get; init; } = null!;
        public string? Active3 { get; init; }
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
        public int Creeps { get; init; }
        public int Damage { get; init; }
        public int DamageBot { get; init; }
        public int DamageDoneInHand { get; init; }
        public int DamageMitigated { get; init; }
        public int DamageStructure { get; init; }
        public int DamageTaken { get; init; }
        public int DamageTakenMagical { get; init; }
        public int DamageTakenPhysical { get; init; }
        public int Deaths { get; init; }
        public int DistanceTraveled { get; init; }
        public string FirstBanSide { get; init; } = null!;
        public string God { get; init; } = null!;
        public int GodId { get; init; }
        public int Gold { get; init; }
        public int Healing { get; init; }
        public int HealingBot { get; init; }
        public int HealingPlayerSelf { get; init; }
        public int ItemId1 { get; init; }
        public int ItemId2 { get; init; }
        public int ItemId3 { get; init; }
        public int ItemId4 { get; init; }
        public int ItemId5 { get; init; }
        public int ItemId6 { get; init; }
        public string Item1 { get; init; } = null!;
        public string Item2 { get; init; } = null!;
        public string Item3 { get; init; } = null!;
        public string Item4 { get; init; } = null!;
        public string Item5 { get; init; } = null!;
        public string Item6 { get; init; } = null!;
        public int KillingSpree { get; init; }
        public int Kills { get; init; }
        public int Level { get; init; }
        public string MapGame { get; init; } = null!;
        public int Match { get; init; }
        public int MatchQueueId { get; init; }
        public string MatchTime { get; init; } = null!;
        public int Minutes { get; init; }
        public int MultiKillMax { get; init; }
        public int ObjectiveAssists { get; init; }
        public string Queue { get; init; } = null!;
        public string Region { get; init; } = null!;
        public string Role { get; init; } = null!;
        public string Skin { get; init; } = null!;
        public int SkinId { get; init; }
        public int Surrendered { get; init; }
        public int TaskForce { get; init; }
        public int Team1Score { get; init; }
        public int Team2Score { get; init; }
        public int TimeInMatchSeconds { get; init; }
        public int WardsPlaced { get; init; }
        public string WinStatus { get; init; } = null!;
        public int WinningTaskForce { get; init; }
        public int PlayerId { get; init; }
        public string PlayerName { get; init; } = null!;
        public string? RetMsg { get; init; }
    }
}
