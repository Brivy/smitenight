﻿namespace Smitenight.Domain.Clients.SmiteClient.Responses.PlayerInfoResponses
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
