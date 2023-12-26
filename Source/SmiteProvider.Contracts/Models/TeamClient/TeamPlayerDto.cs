namespace Smitenight.Providers.SmiteProvider.Contracts.Models.TeamClient;

public record class TeamPlayerDto
{
    public required int AccountLevel { get; init; }
    public required string JoinedDatetime { get; init; }
    public required string LastLoginDatetime { get; init; }
    public required string Name { get; init; }
    public required string PlayerId { get; init; }
    public string? RetMsg { get; init; }
}
