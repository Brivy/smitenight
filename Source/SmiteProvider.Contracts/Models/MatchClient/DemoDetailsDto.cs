namespace Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient;

public record class DemoDetailsDto
{
    public required int BanId1 { get; init; }
    public required int BanId2 { get; init; }
    public required int BanId3 { get; init; }
    public required int BanId4 { get; init; }
    public required string EntryDatetime { get; init; }
    public required int Match { get; init; }
    public required int MatchTime { get; init; }
    public required int OfflineSpectators { get; init; }
    public required string Queue { get; init; }
    public required int RealtimeSpectators { get; init; }
    public required string RecordingEnded { get; init; }
    public required string RecordingStarted { get; init; }
    public required int Team1AvgLevel { get; init; }
    public required int Team1Gold { get; init; }
    public required int Team1Kills { get; init; }
    public required int Team1Score { get; init; }
    public required int Team2AvgLevel { get; init; }
    public required int Team2Gold { get; init; }
    public required int Team2Kills { get; init; }
    public required int Team2Score { get; init; }
    public required int WinningTeam { get; init; }
    public string? RetMsg { get; init; }
}
