namespace Smitenight.Providers.SmiteProvider.Contracts.Models.TeamClient
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
