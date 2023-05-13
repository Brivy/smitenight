namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient
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
