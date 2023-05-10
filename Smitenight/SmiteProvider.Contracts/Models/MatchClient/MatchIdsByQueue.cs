namespace Smitenight.Domain.Models.Clients.MatchClient
{
    public record class MatchIdsByQueue
    (
        string ActiveFlag,
        string Match,
        object RetMsg
    );
}
