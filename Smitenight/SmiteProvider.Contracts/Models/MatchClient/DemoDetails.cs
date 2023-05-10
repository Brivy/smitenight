namespace Smitenight.Domain.Models.Clients.MatchClient
{
    public record class DemoDetails
    (
        int BanId1,
        int BanId2,
        int BanId3,
        int BanId4,
        string EntryDatetime,
        int Match,
        int MatchTime,
        int OfflineSpectators,
        string Queue,
        int RealtimeSpectators,
        string RecordingEnded,
        string RecordingStarted,
        int Team1AvgLevel,
        int Team1Gold,
        int Team1Kills,
        int Team1Score,
        int Team2AvgLevel,
        int Team2Gold,
        int Team2Kills,
        int Team2Score,
        int WinningTeam,
        object RetMsg
    );
}
