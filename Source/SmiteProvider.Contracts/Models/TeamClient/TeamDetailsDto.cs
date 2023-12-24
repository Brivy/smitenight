namespace Smitenight.Providers.SmiteProvider.Contracts.Models.TeamClient;

public record class TeamDetailsDto
{
    public string AvatarUrl { get; init; } = null!;
    public string Founder { get; init; } = null!;
    public string FounderId { get; init; } = null!;
    public int Losses { get; init; }
    public string Name { get; init; } = null!;
    public int Players { get; init; }
    public int Rating { get; init; }
    public string Tag { get; init; } = null!;
    public int TeamId { get; init; }
    public int Wins { get; init; }
    public string? RetMsg { get; init; }
}
