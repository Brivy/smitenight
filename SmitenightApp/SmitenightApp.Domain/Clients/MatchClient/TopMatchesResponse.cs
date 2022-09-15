namespace SmitenightApp.Domain.Clients.MatchClient
{
    public record class TopMatchesResponse
    (
        string Ban1,
        int Ban1Id,
        string Ban2,
        int Ban2Id,
        string EntryDatetime,
        int LiveSpectators,
        int Match,
        int MatchTime,
        int OfflineSpectators,
        string Queue,
        string RecordingFinished,
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
