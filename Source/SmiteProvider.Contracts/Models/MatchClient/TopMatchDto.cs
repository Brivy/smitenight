namespace Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient;

public record class TopMatchDto
{
    public string Ban1 { get; init; } = null!;
    public int Ban1Id { get; init; }
    public string Ban2 { get; init; } = null!;
    public int Ban2Id { get; init; }
    public string EntryDatetime { get; init; } = null!;
    public int LiveSpectators { get; init; }
    public int Match { get; init; }
    public int MatchTime { get; init; }
    public int OfflineSpectators { get; init; }
    public string Queue { get; init; } = null!;
    public string RecordingFinished { get; init; } = null!;
    public string RecordingStarted { get; init; } = null!;
    public int Team1AvgLevel { get; init; }
    public int Team1Gold { get; init; }
    public int Team1Kills { get; init; }
    public int Team1Score { get; init; }
    public int Team2AvgLevel { get; init; }
    public int Team2Gold { get; init; }
    public int Team2Kills { get; init; }
    public int Team2Score { get; init; }
    public int WinningTeam { get; init; }
    public string? RetMsg { get; init; }
}
