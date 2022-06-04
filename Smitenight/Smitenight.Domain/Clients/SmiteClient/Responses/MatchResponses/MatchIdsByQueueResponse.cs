namespace Smitenight.Domain.Clients.SmiteClient.Responses.MatchResponses
{
    public record class MatchIdsByQueueResponse
    (
        string ActiveFlag,
        string Match,
        object RetMsg
    );
}
