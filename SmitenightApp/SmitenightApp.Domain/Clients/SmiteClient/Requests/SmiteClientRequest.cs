using System.Text;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests
{
    public abstract record class SmiteClientRequest
    {
        public string MethodName { get; }
        public bool RequiresSessionId { get; }

        /// <summary>
        /// Builds a request for the SMITE API
        /// Only a handful of requests can be done without a session ID, so by default it's true
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="requiresSessionId"></param>
        protected SmiteClientRequest(string methodName, bool requiresSessionId = true)
        {
            MethodName = methodName;
            RequiresSessionId = requiresSessionId;
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
