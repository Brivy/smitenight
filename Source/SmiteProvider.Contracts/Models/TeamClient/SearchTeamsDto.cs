namespace Smitenight.Providers.SmiteProvider.Contracts.Models.TeamClient;

public record class SearchTeamsDto
{
    public required string Founder { get; init; }
    public required string Name { get; init; }
    public required int Players { get; init; }
    public required string Tag { get; init; }
    public required int TeamId { get; init; }
    public string? RetMsg { get; init; }
}
