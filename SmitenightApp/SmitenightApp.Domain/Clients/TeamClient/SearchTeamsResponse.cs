namespace SmitenightApp.Domain.Clients.TeamClient
{
    public record class SearchTeamsResponse
    (
        string? Founder,
        string? Name,
        int Players,
        string? Tag,
        int TeamId,
        string? RetMsg
    );
}
