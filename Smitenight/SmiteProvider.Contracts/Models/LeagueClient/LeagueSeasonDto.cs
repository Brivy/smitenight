namespace Smitenight.Providers.SmiteProvider.Contracts.Models.LeagueClient
{
    public record class LeagueSeasonDto
    (
        bool Complete,
        int Id,
        string? LeagueDescription,
        string? Name,
        string? RetMsg,
        int Round,
        int Season
    );
}
