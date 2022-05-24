using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.MatchInfoResponses
{
    public record class DemoDetailsResponseDto
    {
        [JsonPropertyName("BanId1")] public int BanId1 { get; init; }
        [JsonPropertyName("BanId2")] public int BanId2 { get; init; }
        [JsonPropertyName("BanId3")] public int BanId3 { get; init; }
        [JsonPropertyName("BanId4")] public int BanId4 { get; init; }
        [JsonPropertyName("Entry_Datetime")] public string? EntryDatetime { get; init; }
        [JsonPropertyName("Match")] public int Match { get; init; }
        [JsonPropertyName("Match_Time")] public int MatchTime { get; init; }
        [JsonPropertyName("Offline_Spectators")] public int OfflineSpectators { get; init; }
        [JsonPropertyName("Queue")] public string? Queue { get; init; }
        [JsonPropertyName("Realtime_Spectators")] public int RealtimeSpectators { get; init; }
        [JsonPropertyName("Recording_Ended")] public string? RecordingEnded { get; init; }
        [JsonPropertyName("Recording_Started")] public string? RecordingStarted { get; init; }
        [JsonPropertyName("Team1_AvgLevel")] public int Team1AvgLevel { get; init; }
        [JsonPropertyName("Team1_Gold")] public int Team1Gold { get; init; }
        [JsonPropertyName("Team1_Kills")] public int Team1Kills { get; init; }
        [JsonPropertyName("Team1_Score")] public int Team1Score { get; init; }
        [JsonPropertyName("Team2_AvgLevel")] public int Team2AvgLevel { get; init; }
        [JsonPropertyName("Team2_Gold")] public int Team2Gold { get; init; }
        [JsonPropertyName("Team2_Kills")] public int Team2Kills { get; init; }
        [JsonPropertyName("Team2_Score")] public int Team2Score { get; init; }
        [JsonPropertyName("Winning_Team")] public int WinningTeam { get; init; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; init; }
    }
}
