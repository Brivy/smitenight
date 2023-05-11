namespace Smitenight.Domain.Models.Clients.PlayerClient
{
    public record class PlayerStatusDto
    (
        int Match,
        int MatchQueueId,
        string PersonalStatusMessage,
        object RetMsg,
        int Status,
        string StatusString
    );
}
