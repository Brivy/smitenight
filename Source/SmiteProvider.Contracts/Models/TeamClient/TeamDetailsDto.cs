namespace Smitenight.Providers.SmiteProvider.Contracts.Models.TeamClient;

public record class TeamDetailsDto
{
    public required string AvatarUrl { get; init; }
    public required string Founder { get; init; }
    public required string FounderId { get; init; }
    public required int Losses { get; init; }
    public required string Name { get; init; }
    public required int Players { get; init; }
    public required int Rating { get; init; }
    public required string Tag { get; init; }
    public required int TeamId { get; init; }
    public required int Wins { get; init; }
    public string? RetMsg { get; init; }
}
