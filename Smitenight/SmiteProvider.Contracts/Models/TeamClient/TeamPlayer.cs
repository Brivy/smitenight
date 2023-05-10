namespace Smitenight.Domain.Models.Clients.TeamClient
{
    public record class TeamPlayer
    (
        int AccountLevel,
        string? JoinedDatetime,
        string? LastLoginDatetime,
        string? Name,
        string? PlayerId,
        string? RetMsg
    );
}
