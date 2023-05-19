namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient
{
    public record class GodLeaderboardDto
    {
        public string GodId { get; init; } = null!;
        public string Losses { get; init; } = null!;
        public string PlayerId { get; init; } = null!;
        public string PlayerName { get; init; } = null!;
        public string PlayerRanking { get; init; } = null!;
        public string Rank { get; init; } = null!;
        public string? RetMsg { get; init; }
        public string Wins { get; init; } = null!;
    }
}
