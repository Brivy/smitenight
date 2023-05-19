namespace Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient
{
    public record class MatchIdsByQueueDto
    {
        public string ActiveFlag { get; init; } = null!;
        public string Match { get; init; } = null!;
        public string? RetMsg { get; init; }
    }
}
