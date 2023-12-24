namespace Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient;

public record class DemoDetailsDto
{
    public int BanId1 { get; init; }
    public int BanId2 { get; init; }
    public int BanId3 { get; init; }
    public int BanId4 { get; init; }
    public string EntryDatetime { get; init; } = null!;
    public int Match { get; init; }
    public int MatchTime { get; init; }
    public int OfflineSpectators { get; init; }
    public string Queue { get; init; } = null!;
    public int RealtimeSpectators { get; init; }
    public string RecordingEnded { get; init; } = null!;
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
