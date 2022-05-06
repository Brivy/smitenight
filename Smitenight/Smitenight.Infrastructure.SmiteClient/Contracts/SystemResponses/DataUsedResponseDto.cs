using System.Text.Json.Serialization;

namespace Smitenight.Infrastructure.SmiteClient.Contracts.SystemResponses
{
    public record class DataUsedResponseDto(
        [property: JsonPropertyName("Active_Sessions")] int ActiveSessions,
        [property: JsonPropertyName("Concurrent_Sessions")] int ConcurrentSessions, 
        [property: JsonPropertyName("Request_Limit_Daily")] int RequestLimitDaily,
        [property: JsonPropertyName("Session_Cap")] int SessionCap,
        [property: JsonPropertyName("Session_Time_Limit")] int SessionTimeLimit,
        [property: JsonPropertyName("Total_Requests_Today")] int TotalRequestsToday,
        [property: JsonPropertyName("Total_Sessions_Today")] int TotalSessionsToday,
        [property: JsonPropertyName("ret_msg")] object RetMsg);
}
