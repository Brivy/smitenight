namespace Smitenight.Domain.Models.Clients.MatchClient
{
    public record class MatchIdsByQueueDto
    (
        string ActiveFlag,
        string Match,
        object RetMsg
    );
}
