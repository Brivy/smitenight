﻿namespace Smitenight.Domain.Clients.SmiteClient.Responses.SystemResponses
{
    public record class PatchInfoResponse(
        object RetMsg,
        string VersionString);
}