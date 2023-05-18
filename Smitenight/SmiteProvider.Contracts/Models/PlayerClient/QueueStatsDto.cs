namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient
{
    public record class QueueStatsDto
    {
        public int Assists { get; init; }
        public int Deaths { get; init; }
        public string God { get; init; } = null!;
        public int GodId { get; init; }
        public int Gold { get; init; }
        public int Kills { get; init; }
        public string LastPlayed { get; init; } = null!;
        public int Losses { get; init; }
        public int Matches { get; init; }
        public int Minutes { get; init; }
        public string Queue { get; init; } = null!;
        public int Wins { get; init; }
        public string PlayerId { get; init; } = null!;
        public string? RetMsg { get; init; }
    }

}
