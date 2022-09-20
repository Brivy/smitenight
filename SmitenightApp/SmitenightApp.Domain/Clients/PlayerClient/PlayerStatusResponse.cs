﻿namespace SmitenightApp.Domain.Clients.PlayerClient
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
