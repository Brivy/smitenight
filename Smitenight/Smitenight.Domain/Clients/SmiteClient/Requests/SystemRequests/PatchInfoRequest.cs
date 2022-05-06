﻿namespace Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests
{
    public record class PatchInfoRequest : SmiteClientRequest
    {
        public PatchInfoRequest(
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