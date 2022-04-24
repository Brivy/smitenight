using Microsoft.Extensions.Options;
using Smitenight.Providers.SmiteProvider.HiRez.Cache;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Utilities.Time.Common.Constants;
using System.Text;

namespace Smitenight.Providers.SmiteProvider.HiRez.Services;

public class SmiteClientUrlService(
    ISmiteSessionCacheService smiteSessionCacheService,
    ISmiteHashService smiteHashService,
    IOptions<SmiteClientSecrets> smiteClientSecrets,
    TimeProvider timeProvider) : ISmiteClientUrlService
{
    private readonly ISmiteSessionCacheService _smiteSessionCacheService = smiteSessionCacheService;
    private readonly ISmiteHashService _smiteHashService = smiteHashService;
    private readonly TimeProvider _timeProvider = timeProvider;

    private readonly SmiteClientSecrets _smiteClientSecrets = smiteClientSecrets.Value;

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
        string utcDateString = _timeProvider.GetUtcNow().ToString(DateTimeFormat.SessionIdFormat);
        string signature = _smiteHashService.GenerateSmiteHash(methodName, utcDateString);
        string sessionId = await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken);
        string urlPathSegment = !string.IsNullOrWhiteSpace(urlPath) ? $"/{urlPath}" : string.Empty;
        return $"{methodName}Json/{_smiteClientSecrets.DeveloperId}/{signature}/{sessionId}/{utcDateString}{urlPathSegment}";
    }

    public string ConstructUrlPath(params object[] urlPaths)
    {
        if (urlPaths.Length == 0)
        {
            return string.Empty;
        }

        var sb = new StringBuilder();
        foreach (object urlPath in urlPaths)
        {
            sb.Append($"{urlPath.ToString()}/");
        }

        // Remove last slash
        sb.Length--;
        return sb.ToString();
    }
}
