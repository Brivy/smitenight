using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.MatchClient;

public record class TopMatch
{
    [JsonPropertyName("Ban1")] public string? Ban1 { get; init; }
    [JsonPropertyName("Ban1Id")] public int Ban1Id { get; init; }
    [JsonPropertyName("Ban2")] public string? Ban2 { get; init; }
    [JsonPropertyName("Ban2Id")] public int Ban2Id { get; init; }
    [JsonPropertyName("Entry_Datetime")] public string? EntryDatetime { get; init; }
    [JsonPropertyName("LiveSpectators")] public int LiveSpectators { get; init; }
    [JsonPropertyName("Match")] public int Match { get; init; }
    [JsonPropertyName("Match_Time")] public int MatchTime { get; init; }
    [JsonPropertyName("OfflineSpectators")] public int OfflineSpectators { get; init; }
    [JsonPropertyName("Queue")] public string? Queue { get; init; }
    [JsonPropertyName("RecordingFinished")] public string? RecordingFinished { get; init; }
    [JsonPropertyName("RecordingStarted")] public string? RecordingStarted { get; init; }
    [JsonPropertyName("Team1_AvgLevel")] public int Team1AvgLevel { get; init; }
    [JsonPropertyName("Team1_Gold")] public int Team1Gold { get; init; }
    [JsonPropertyName("Team1_Kills")] public int Team1Kills { get; init; }
    [JsonPropertyName("Team1_Score")] public int Team1Score { get; init; }
    [JsonPropertyName("Team2_AvgLevel")] public int Team2AvgLevel { get; init; }
    [JsonPropertyName("Team2_Gold")] public int Team2Gold { get; init; }
    [JsonPropertyName("Team2_Kills")] public int Team2Kills { get; init; }
    [JsonPropertyName("Team2_Score")] public int Team2Score { get; init; }
    [JsonPropertyName("WinningTeam")] public int WinningTeam { get; init; }
    [JsonPropertyName("ret_msg")] public string? RetMsg { get; init; }
}
