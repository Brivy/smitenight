namespace Smitenight.Domain.Clients.SmiteClient.Responses.LeagueResponses
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
