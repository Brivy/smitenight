namespace Smitenight.Providers.SmiteProvider.Contracts.Models.OtherClient;

public record class MotdDto
{
    public required string Description { get; init; }
    public required string GameMode { get; init; }
    public required string MaxPlayers { get; init; }
    public required string Name { get; init; }
    public string? RetMsg { get; init; }
    public required string StartDateTime { get; init; }
    public required string Team1GodsCsv { get; init; }
    public required string Team2GodsCsv { get; init; }
    public required string Title { get; init; }
}
