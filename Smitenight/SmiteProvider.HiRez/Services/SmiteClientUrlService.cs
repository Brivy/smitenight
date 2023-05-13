using Clock.Common.Constants;
using Microsoft.Extensions.Options;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Providers.SmiteProvider.HiRez.Cache;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Providers.SmiteProvider.HiRez.Settings;
using System.Security.Cryptography;
using System.Text;

namespace Smitenight.Providers.SmiteProvider.HiRez.Services
{
    public class SmiteClientUrlService : ISmiteClientUrlService
    {
        private readonly ISmiteSessionCacheService _smiteSessionCacheService;
        private readonly SmiteClientSettings _smiteClientSettings;
        private readonly SmiteClientSecrets _smiteClientSecrets;

        public SmiteClientUrlService(
            ISmiteSessionCacheService smiteSessionCacheService,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets)
        {
            _smiteSessionCacheService = smiteSessionCacheService;
            _smiteClientSettings = smiteClientSettings.Value;
            _smiteClientSecrets = smiteClientSecrets.Value;
        }

        public string ConstructPingUrl()
        {
            return $"{_smiteClientSettings.Url}{MethodNameConstants.TestSessionMethod}Json";
        }

        public Task<string> ConstructUrlAsync(string methodName, CancellationToken cancellationToken = default)
        {
            return ConstructUrlAsync(methodName, null, cancellationToken);
        }

        public async Task<string> ConstructUrlAsync(string methodName, string? urlPath, CancellationToken cancellationToken = default)
        {
            var utcDateString = GetCurrentUtcDate();
            var signature = GenerateMd5Hash(methodName, utcDateString);
            var sessionId = await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken);
            var urlPathSegment = !string.IsNullOrWhiteSpace(urlPath) ? $"/{urlPath}" : string.Empty;
            return $"{_smiteClientSettings.Url}/{methodName}Json/{_smiteClientSecrets.DeveloperId}/{signature}/{sessionId}/{utcDateString}{urlPathSegment}";
        }

        public string ConstructUrlPath(params object[] urlPaths)
        {
            if (!urlPaths.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            foreach (var urlPath in urlPaths)
            {
                sb.Append($"{urlPath.ToString()}/");
            }

            // Remove last slash
            sb.Length--;
            return sb.ToString();
        }

        /// <summary>
        /// Creates a MD5 hash from the method we are calling and our credentials
        /// This is needed for each request to Smite (except Ping)
        /// </summary>
        /// <returns></returns>
        private string GenerateMd5Hash(string methodName, string utcDateString)
        {
            var credentials = $"{_smiteClientSecrets.DeveloperId}{methodName}{_smiteClientSecrets.AuthenticationKey}{utcDateString}";

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
    }
}
