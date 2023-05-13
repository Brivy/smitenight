namespace Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient
{
    public record class DataUsedDto(
        int ActiveSessions,
        int ConcurrentSessions,
        int RequestLimitDaily,
        int SessionCap,
        int SessionTimeLimit,
        int TotalRequestsToday,
        int TotalSessionsToday,
        object RetMsg);
}
