namespace Smitenight.Providers.SmiteProvider.Contracts.Models.TeamClient;

public record class SearchTeamsDto
{
    public string Founder { get; init; } = null!;
    public string Name { get; init; } = null!;
    public int Players { get; init; }
    public string Tag { get; init; } = null!;
    public int TeamId { get; init; }
    public string? RetMsg { get; init; }
}
