namespace SmitenightApp.Infrastructure.SmiteClient.Models
{
    public record SmiteClientRequest
    {
        public string MethodName { get; }
        public string? UrlPath { get; }
        public bool RequireSessionId { get; }

        public SmiteClientRequest(string methodName, bool requiresSessionId = true)
        {
            MethodName = methodName;
            RequireSessionId = requiresSessionId;
        }

        public SmiteClientRequest(string methodName, string urlPath, bool requiresSessionId = true)
        {
            MethodName = methodName;
            UrlPath = urlPath;
            RequireSessionId = requiresSessionId;
        }
    }
}
