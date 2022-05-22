using System.Text;
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

        /// <summary>
        /// Returns the url path for the given request
        /// Calling this without override will return the default url path
        /// </summary>
        /// <returns></returns>
        public virtual string GetUrlPath() =>
            ConstructUrlPath();

        /// <summary>
        /// Construct the query string based on given url path parameters
        /// </summary>
        /// <param name="urlPaths">A collection of url path parameters</param>
        /// <returns></returns>
        protected string ConstructUrlPath(params object[] urlPaths)
        {
            var baseUrlPath = ConstructBaseUrlPath();
            var sb = new StringBuilder(baseUrlPath);
            foreach (var urlPath in urlPaths)
            {
                sb.Append($"{urlPath.ToString()}/");
            }

            // Remove last slash
            sb.Length--;
            return sb.ToString();
        }

        #region Private functionality

        /// <summary>
        /// Constructs the base of the url path string needed for each request
        /// </summary>
        /// <returns></returns>
        private string ConstructBaseUrlPath()
        {
            var baseUrlPath = $"{MethodName}{ResponseType}/";
            if (DeveloperId != 0)
            {
                baseUrlPath += $"{DeveloperId}/";
            }

            if (!string.IsNullOrWhiteSpace(Signature))
            {
                baseUrlPath += $"{Signature}/";
            }

            if (!string.IsNullOrWhiteSpace(SessionId))
            {
                baseUrlPath += $"{SessionId}/";
            }

            if (!string.IsNullOrWhiteSpace(CurrentDate))
            {
                baseUrlPath += $"{CurrentDate}/";
            }

            return baseUrlPath;
        }

        #endregion
    }
}
