namespace Smitenight.Providers.SmiteProvider.Contracts.Models.RetrievePlayerClient
{
    public record class PlayerDto
    {
        public int ActivePlayerId { get; init; }
        public string AvatarUrl { get; init; } = null!;
        public string CreatedDatetime { get; init; } = null!;
        public int HoursPlayed { get; init; }
        public int Id { get; init; }
        public string LastLoginDatetime { get; init; } = null!;
        public int Leaves { get; init; }
        public int Level { get; init; }
        public int Losses { get; init; }
        public int MasteryLevel { get; init; }
        public string MergedPlayers { get; init; } = null!;
        public int MinutesPlayed { get; init; }
        public string Name { get; init; } = null!;
        public string PersonalStatusMessage { get; init; } = null!;
        public string Platform { get; init; } = null!;
        public float RankStatConquest { get; init; }
        public float RankStatConquestController { get; init; }
        public float RankStatDuel { get; init; }
        public float RankStatDuelController { get; init; }
        public float RankStatJoust { get; init; }
        public float RankStatJoustController { get; init; }
        public RankedDetailsDto RankedConquest { get; init; } = null!;
        public RankedDetailsDto RankedConquestController { get; init; } = null!;
        public RankedDetailsDto RankedDuel { get; init; } = null!;
        public RankedDetailsDto RankedDuelController { get; init; } = null!;
        public RankedDetailsDto RankedJoust { get; init; } = null!;
        public RankedDetailsDto RankedJoustController { get; init; } = null!;
        public string Region { get; init; } = null!;
        public int TeamId { get; init; }
        public string TeamName { get; init; } = null!;
        public int TierConquest { get; init; }
        public int TierDuel { get; init; }
        public int TierJoust { get; init; }
        public int TotalAchievements { get; init; }
        public int TotalWorshippers { get; init; }
        public int Wins { get; init; }
        public string HzGamerTag { get; init; } = null!;
        public string HzPlayerName { get; init; } = null!;
        public string? RetMsg { get; init; }
    }
}