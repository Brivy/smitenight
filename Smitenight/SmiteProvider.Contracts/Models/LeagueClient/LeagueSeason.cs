namespace Smitenight.Domain.Models.Clients.LeagueClient
{
    public record class LeagueSeason
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
