namespace SmitenightApp.Domain.Clients.MatchClient
{
    public record class MatchIdsByQueueResponse
    (
        string ActiveFlag,
        string Match,
        object RetMsg
    );
}
