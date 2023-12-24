namespace Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;

public record class DataUsedDto
{
    public int ActiveSessions { get; init; }
    public int ConcurrentSessions { get; init; }
    public int RequestLimitDaily { get; init; }
    public int SessionCap { get; init; }
    public int SessionTimeLimit { get; init; }
    public int TotalRequestsToday { get; init; }
    public int TotalSessionsToday { get; init; }
    public string? RetMsg { get; init; }
}
