namespace Smitenight.Domain.Clients.SmiteClient.Responses.PlayerInfoResponses
{
    public record class GodRanksResponse
    (
        int Assists,
        int Deaths,
        int Kills,
        int Losses,
        int MinionKills,
        int Rank,
        int Wins,
        int Worshippers,
        string God,
        string GodId,
        string PlayerId,
        object RetMsg
    );
}
