namespace Smitenight.Domain.Clients.SmiteClient.Responses.MatchInfoResponses
{
    public record class MatchIdsByQueueResponse
    (
        string ActiveFlag,
        string Match,
        object RetMsg
    );
}
