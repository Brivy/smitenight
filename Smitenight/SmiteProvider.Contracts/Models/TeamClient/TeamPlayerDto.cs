namespace Smitenight.Domain.Models.Clients.TeamClient
{
    public record class TeamPlayerDto
    (
        int AccountLevel,
        string? JoinedDatetime,
        string? LastLoginDatetime,
        string? Name,
        string? PlayerId,
        string? RetMsg
    );
}
