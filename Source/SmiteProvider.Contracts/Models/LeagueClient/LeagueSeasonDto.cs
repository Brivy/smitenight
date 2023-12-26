namespace Smitenight.Providers.SmiteProvider.Contracts.Models.LeagueClient;

public record class LeagueSeasonDto
{
    public required bool Complete { get; init; }
    public required int Id { get; init; }
    public required string LeagueDescription { get; init; }
    public required string Name { get; init; }
    public required string RetMsg { get; init; }
    public required int Round { get; init; }
    public required int Season { get; init; }
}
