namespace Smitenight.Domain.Models.Clients.PlayerClient
{
    public record class PlayerStatus
    (
        int Match,
        int MatchQueueId,
        string PersonalStatusMessage,
        object RetMsg,
        int Status,
        string StatusString
    );
}
