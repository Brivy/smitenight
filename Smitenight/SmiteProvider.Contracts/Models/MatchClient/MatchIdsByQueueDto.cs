namespace Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient
{
    public record class MatchIdsByQueueDto
    (
        string ActiveFlag,
        string Match,
        object RetMsg
    );
}
