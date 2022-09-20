namespace SmitenightApp.Domain.Clients.LeagueClient
{
    public record class LeagueSeasonsResponse
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
