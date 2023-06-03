using Microsoft.Extensions.Options;
using Smitenight.Providers.SmiteProvider.HiRez.Cache;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Utilities.Clock.Constants;
using System.Text;

namespace Smitenight.Providers.SmiteProvider.HiRez.Services
{
    public class SmiteClientUrlService : ISmiteClientUrlService
    {
        private readonly ISmiteSessionCacheService _smiteSessionCacheService;
        private readonly ISmiteHashService _smiteHashService;
        private readonly SmiteClientSecrets _smiteClientSecrets;

        public SmiteClientUrlService(
            ISmiteSessionCacheService smiteSessionCacheService,
            ISmiteHashService smiteHashService,
            IOptions<SmiteClientSecrets> smiteClientSecrets)
        {
            _smiteSessionCacheService = smiteSessionCacheService;
            _smiteHashService = smiteHashService;
            _smiteClientSecrets = smiteClientSecrets.Value;
        }

        public string ConstructPingUrl()
        {
            return $"{MethodNameConstants.TestSessionMethod}Json";
        }

        public Task<string> ConstructUrlAsync(string methodName, CancellationToken cancellationToken = default)
        {
            return ConstructUrlAsync(methodName, null, cancellationToken);
        }

        public async Task<string> ConstructUrlAsync(string methodName, string? urlPath, CancellationToken cancellationToken = default)
        {
            var utcDateString = DateTime.UtcNow.ToString(DateTimeFormats.SessionIdFormat);
            var signature = _smiteHashService.GenerateSmiteHash(methodName, utcDateString);
            var sessionId = await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken);
            var urlPathSegment = !string.IsNullOrWhiteSpace(urlPath) ? $"/{urlPath}" : string.Empty;
            return $"{methodName}Json/{_smiteClientSecrets.DeveloperId}/{signature}/{sessionId}/{utcDateString}{urlPathSegment}";
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
    }
}
