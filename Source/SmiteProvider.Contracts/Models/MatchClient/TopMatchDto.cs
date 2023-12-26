namespace Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient;

public record class TopMatchDto
{
    public required string Ban1 { get; init; }
    public required int Ban1Id { get; init; }
    public required string Ban2 { get; init; }
    public required int Ban2Id { get; init; }
    public required string EntryDatetime { get; init; }
    public required int LiveSpectators { get; init; }
    public required int Match { get; init; }
    public required int MatchTime { get; init; }
    public required int OfflineSpectators { get; init; }
    public required string Queue { get; init; }
    public required string RecordingFinished { get; init; }
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
