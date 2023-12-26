namespace Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient;

public record class MatchIdsByQueueDto
{
    public required string ActiveFlag { get; init; }
    public required string Match { get; init; }
    public string? RetMsg { get; init; }
}
