﻿namespace Smitenight.Domain.Models.Clients.SystemClient
{
    public record class DataUsed(
        int ActiveSessions,
        int ConcurrentSessions,
        int RequestLimitDaily,
        int SessionCap,
        int SessionTimeLimit,
        int TotalRequestsToday,
        int TotalSessionsToday,
        object RetMsg);
}