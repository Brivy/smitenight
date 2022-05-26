using System.Security.Cryptography;
using System.Text;
using Smitenight.Domain.Constants;

namespace Smitenight.Domain.Clients.SmiteClient.Requests
{
    public abstract record class SmiteClientRequest
    {
        public int DeveloperId { get; }
        public string? AuthenticationKey { get; }
        public string MethodName { get; }
        public string? SessionId { get; }

        /// <summary>
        /// Intended for pinging the Hirez servers
        /// </summary>
        /// <param name="methodName">Name of the Smite endpoint</param>
        protected SmiteClientRequest(string methodName)
        {
            MethodName = methodName;
        }

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
            var utcDateString = GetCurrentUtcDate();
            var baseUrlPath = $"{MethodName}Json/";
            if (DeveloperId != 0)
            {
                baseUrlPath += $"{DeveloperId}/";
            }

            if (DeveloperId != 0 && !string.IsNullOrWhiteSpace(AuthenticationKey))
            {
                var signature = GenerateMd5Hash(utcDateString);
                baseUrlPath += $"{signature}/";
            }

            if (!string.IsNullOrWhiteSpace(SessionId))
            {
                baseUrlPath += $"{SessionId}/";
            }

            if (!string.IsNullOrWhiteSpace(utcDateString))
            {
                baseUrlPath += $"{utcDateString}/";
            }

            return baseUrlPath;
        }

        /// <summary>
        /// Creates a MD5 hash from the method we are calling and our credentials
        /// This is needed for each request to Smite (except Ping)
        /// </summary>
        /// <returns></returns>
        private string GenerateMd5Hash(string utcDateString)
        {
            var credentials = $"{DeveloperId}{MethodName}{AuthenticationKey}{utcDateString}";

            using var md5 = MD5.Create();
            var bytes = md5.ComputeHash(Encoding.ASCII.GetBytes(credentials));
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("x2").ToLower());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Converts the current UTC date to a string in the <see cref="DateTimeFormats.SessionIdFormat"/> format
        /// </summary>
        /// <returns></returns>
        private static string GetCurrentUtcDate() =>
            DateTime.UtcNow.ToString(DateTimeFormats.SessionIdFormat);

        #endregion
    }
}
