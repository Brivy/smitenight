using System.Security.Cryptography;
using System.Text;
using Smitenight.Domain.Constants;

namespace Smitenight.Domain.Clients.SmiteClient.Requests
{
    public abstract record class SmiteClientRequest
    {
        public int DeveloperId { get; }
        public string AuthenticationKey { get; }
        public string MethodName { get; }
        public string? SessionId { get; }
        public string? UrlPath { get; set; }

        /// <summary>
        /// Intended for creating sessions
        /// </summary>
        /// <param name="developerId">Smite developers ID</param>
        /// <param name="authenticationKey">Smite developers authentication key</param>
        /// <param name="methodName">Name of the Smite endpoint</param>
        protected SmiteClientRequest(int developerId, string authenticationKey, string methodName)
        {
            DeveloperId = developerId;
            AuthenticationKey = authenticationKey;
            MethodName = methodName;
        }

        /// <summary>
        /// Intended for all Smite calls except pinging and creating sessions
        /// </summary>
        /// <param name="developerId">Smite developers ID</param>
        /// <param name="authenticationKey">Smite developers authentication key</param>
        /// <param name="methodName">Name of the Smite endpoint</param>
        /// <param name="sessionId">The ID of the generated session</param>
        protected SmiteClientRequest(int developerId, string authenticationKey, string methodName, string sessionId)
        {
            DeveloperId = developerId;
            AuthenticationKey = authenticationKey;
            MethodName = methodName;
            SessionId = sessionId;
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
            var sb = new StringBuilder();
            foreach (var urlPath in urlPaths)
            {
                sb.Append($"{urlPath.ToString()}/");
            }

            // Remove last slash
            sb.Length--;
            return sb.ToString();
        }
    }
}
