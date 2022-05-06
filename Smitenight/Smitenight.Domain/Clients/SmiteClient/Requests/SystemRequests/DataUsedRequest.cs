﻿namespace Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests
{
    public record class DataUsedRequest : SmiteClientRequest
    {
        public DataUsedRequest(
            int developerId, 
            string methodName, 
            string responseType, 
            string signature, 
            string sessionId, 
            string currentDate) : base(developerId, methodName, responseType, signature, sessionId, currentDate)
        {

        }
    }
}