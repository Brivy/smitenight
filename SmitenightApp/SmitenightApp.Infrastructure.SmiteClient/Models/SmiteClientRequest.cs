﻿namespace SmitenightApp.Infrastructure.SmiteClient.Models
{
    public record SmiteClientRequest
    {
        public string MethodName { get; }
        public string? UrlPath { get; }
        public string? SessionId { get; }

        public SmiteClientRequest(string methodName)
        {
            MethodName = methodName;
        }

        public SmiteClientRequest(string methodName, string sessionId)
        {
            MethodName = methodName;
            SessionId = sessionId;
        }

        public SmiteClientRequest(string methodName, string sessionId, string urlPath)
        {
            MethodName = methodName;
            UrlPath = urlPath;
            SessionId = sessionId;
        }
    }
}
