namespace SmitenightApp.Domain.Clients.TeamClient
{
    public record class TeamPlayersResponse
    (
        int AccountLevel,
        string? JoinedDatetime,
        string? LastLoginDatetime,
        string? Name,
        string? PlayerId,
        string? RetMsg
    );
}
