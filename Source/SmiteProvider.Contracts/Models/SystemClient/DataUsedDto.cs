namespace Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;

public record class DataUsedDto
{
    public required int ActiveSessions { get; init; }
    public required int ConcurrentSessions { get; init; }
    public required int RequestLimitDaily { get; init; }
    public required int SessionCap { get; init; }
    public required int SessionTimeLimit { get; init; }
    public required int TotalRequestsToday { get; init; }
    public required int TotalSessionsToday { get; init; }
    public string? RetMsg { get; init; }
}
