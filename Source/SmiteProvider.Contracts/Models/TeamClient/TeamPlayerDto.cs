namespace Smitenight.Providers.SmiteProvider.Contracts.Models.TeamClient;

public record class TeamPlayerDto
{
    public int AccountLevel { get; init; }
    public string JoinedDatetime { get; init; } = null!;
    public string LastLoginDatetime { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string PlayerId { get; init; } = null!;
    public string? RetMsg { get; init; }
}
