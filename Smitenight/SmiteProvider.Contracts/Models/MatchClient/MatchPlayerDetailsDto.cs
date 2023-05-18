namespace Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient
{
    public record class MatchPlayerDetailsDto
    {
        public int AccountGodsPlayed { get; init; }
        public int AccountLevel { get; init; }
        public int GodId { get; init; }
        public int GodLevel { get; init; }
        public string GodName { get; init; } = null!;
        public int MasteryLevel { get; init; }
        public int Match { get; init; }
        public string Queue { get; init; } = null!;
        public int RankStat { get; init; }
        public int SkinId { get; init; }
        public int Tier { get; init; }
        public string MapGame { get; init; } = null!;
        public string PlayerCreated { get; init; } = null!;
        public string PlayerId { get; init; } = null!;
        public string PlayerName { get; init; } = null!;
        public string PlayerRegion { get; init; } = null!;
        public string? RetMsg { get; init; }
        public int TaskForce { get; init; }
        public int TierLosses { get; init; }
        public int TierPoints { get; init; }
        public int TierWins { get; init; }
    }
}
