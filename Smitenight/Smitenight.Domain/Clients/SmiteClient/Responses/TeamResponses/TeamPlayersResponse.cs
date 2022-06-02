namespace Smitenight.Domain.Clients.SmiteClient.Responses.TeamResponses
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
