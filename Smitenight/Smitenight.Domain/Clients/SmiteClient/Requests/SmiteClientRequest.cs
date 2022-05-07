using Smitenight.Domain.Constants;

namespace Smitenight.Domain.Clients.SmiteClient.Requests
{
    public abstract record class SmiteClientRequest
    {
        public int DeveloperId { get; }
        public string MethodName { get; }
        public string ResponseType { get; }
        public string? Signature { get; }
        public string? SessionId { get; }
        public string? CurrentDate { get; }

        /// <summary>
        /// Intended for pinging the Hirez servers
        /// </summary>
        /// <param name="methodName">Name of the Smite endpoint</param>
        /// <param name="responseType">Type of response: Json or Xml</param>
        protected SmiteClientRequest(string methodName, string responseType)
        {
            MethodName = methodName;
            ResponseType = responseType;
        }

        /// <summary>
        /// Intended for creating sessions
        /// </summary>
        /// <param name="developerId">Smite developers ID</param>
        /// <param name="methodName">Name of the Smite endpoint</param>
        /// <param name="responseType">Type of response: Json or Xml</param>
        /// <param name="signature">The ID of the generated session</param>
        /// <param name="currentDate">Date format in '<see cref="DateTimeFormats.SessionIdFormat"/>'</param>
        protected SmiteClientRequest(int developerId, string methodName, string responseType, string signature, string currentDate)
        {
            DeveloperId = developerId;
            MethodName = methodName;
            ResponseType = responseType;
            Signature = signature;
            CurrentDate = currentDate;
        }

        /// <summary>
        /// Intended for all Smite calls except pinging and creating sessions
        /// </summary>
        /// <param name="developerId">Smite developers ID</param>
        /// <param name="methodName">Name of the Smite endpoint</param>
        /// <param name="responseType">Type of response: Json or Xml</param>
        /// <param name="signature">A generated MD5 hash for authenticating with the servers</param>
        /// <param name="sessionId">The ID of the generated session</param>
        /// <param name="currentDate">Date format in '<see cref="DateTimeFormats.SessionIdFormat"/>'</param>
        protected SmiteClientRequest(int developerId, string methodName, string responseType, string signature,
            string sessionId, string currentDate)
        {
            DeveloperId = developerId;
            MethodName = methodName;
            ResponseType = responseType;
            Signature = signature;
            SessionId = sessionId;
            CurrentDate = currentDate;
        }
    }
}
