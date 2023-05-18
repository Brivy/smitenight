namespace Smitenight.Providers.SmiteProvider.Contracts.Models.OtherClient
{
    public record class MotdDto
    {
        public string Description { get; init; } = null!;
        public string GameMode { get; init; } = null!;
        public string MaxPlayers { get; init; } = null!;
        public string Name { get; init; } = null!;
        public string? RetMsg { get; init; }
        public string StartDateTime { get; init; } = null!;
        public string Team1GodsCsv { get; init; } = null!;
        public string Team2GodsCsv { get; init; } = null!;
        public string Title { get; init; } = null!;
    }
}
