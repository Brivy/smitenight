﻿namespace Smitenight.Domain.Clients.SmiteClient.Requests.PlayerInfoRequests
{
    public record class PlayerStatusRequest(
        int DeveloperId,
        string MethodName,
        string ResponseType,
        string Signature,
        string SessionId,
        string CurrentDate,
        string PlayerId) : SmiteClientRequest(DeveloperId, MethodName, ResponseType, Signature, SessionId, CurrentDate);
}