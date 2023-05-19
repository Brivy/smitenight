namespace Smitenight.Providers.SmiteProvider.Contracts.Models.LeagueClient
{
    public record class LeagueSeasonDto
    {
        public bool Complete { get; init; }
        public int Id { get; init; }
        public string LeagueDescription { get; init; } = null!;
        public string Name { get; init; } = null!;
        public string RetMsg { get; init; } = null!;
        public int Round { get; init; }
        public int Season { get; init; }
    }
}
