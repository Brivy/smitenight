using System.Text;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests
{
    public abstract record class SmiteClientRequest
    {
        public string MethodName { get; }
        public string? SessionId { get; }

        /// <summary>
        /// Intended for creating sessions
        /// </summary>
        /// <param name="methodName">Name of the Smite endpoint</param>
        protected SmiteClientRequest(string methodName)
        {
            MethodName = methodName;
        }

        /// <summary>
        /// Intended for all Smite calls except pinging and creating sessions
        /// </summary>
        /// <param name="methodName">Name of the Smite endpoint</param>
        /// <param name="sessionId">The ID of the generated session</param>
        protected SmiteClientRequest(string methodName, string sessionId)
        {
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
            if (!urlPaths.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder("/");
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
