namespace SmitenightApp.Domain.Clients.SmiteClient.Responses.PlayerResponses
{
    public record class PlayerStatusResponse
    (
        int Match,
        int MatchQueueId,
        string PersonalStatusMessage,
        object RetMsg,
        int Status,
        string StatusString
    );
}
