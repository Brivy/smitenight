namespace Smitenight.Domain.Models.Clients.MatchClient
{
    public record class MatchIdsByQueueResponse
    (
        string ActiveFlag,
        string Match,
        object RetMsg
    );
}
