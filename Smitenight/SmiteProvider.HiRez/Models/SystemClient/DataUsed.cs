using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.SystemClient
{
    public record class DataUsed
    {
        [JsonPropertyName("Active_Sessions")] public int ActiveSessions { get; set; }
        [JsonPropertyName("Concurrent_Sessions")] public int ConcurrentSessions { get; set; }
        [JsonPropertyName("Request_Limit_Daily")] public int RequestLimitDaily { get; set; }
        [JsonPropertyName("Session_Cap")] public int SessionCap { get; set; }
        [JsonPropertyName("Session_Time_Limit")] public int SessionTimeLimit { get; set; }
        [JsonPropertyName("Total_Requests_Today")] public int TotalRequestsToday { get; set; }
        [JsonPropertyName("Total_Sessions_Today")] public int TotalSessionsToday { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
    }
}
