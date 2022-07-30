namespace SmitenightApp.Domain.Clients.SmiteClient.Responses.SystemResponses
{
    public record class DataUsedResponse(
        int ActiveSessions,
        int ConcurrentSessions,
        int RequestLimitDaily, 
        int SessionCap, 
        int SessionTimeLimit, 
        int TotalRequestsToday, 
        int TotalSessionsToday,
        object RetMsg);
}
