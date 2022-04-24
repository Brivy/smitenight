using Microsoft.Extensions.Caching.Distributed;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;
using Smitenight.Utilities.Cache.Contracts.Providers;
using System.Collections.Concurrent;

namespace Smitenight.Providers.SmiteProvider.HiRez.Cache;

public class SmiteSessionCacheService(
    ISmiteSessionClient smiteSessionClient,
    IRedisCacheProvider redisCacheProvider,
    TimeProvider timeProvider) : ISmiteSessionCacheService
{
    private readonly ISmiteSessionClient _smiteSessionClient = smiteSessionClient;
    private readonly IRedisCacheProvider _redisCacheProvider = redisCacheProvider;
    private readonly TimeProvider _timeProvider = timeProvider;
    private readonly ConcurrentDictionary<object, SemaphoreSlim> _locks = new ConcurrentDictionary<object, SemaphoreSlim>();


    /// <summary>
    /// Retrieve the session ID from Smite and store it in the cache
    /// By making use of <see cref="SemaphoreSlim"/>, it will wait when multiple threads try to call the SMITE API at once
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<string> GetSessionIdAsync(CancellationToken cancellationToken = default)
    {
        string cacheKey = _redisCacheProvider.GenerateCacheKey(CacheKeys.SmiteSessionCacheKey);
        SmiteSessionCacheItem? smiteSessionCacheItem = await _redisCacheProvider.GetAsync<SmiteSessionCacheItem>(cacheKey, cancellationToken);
        if (!string.IsNullOrWhiteSpace(smiteSessionCacheItem?.SessionId))
        {
            return smiteSessionCacheItem.SessionId;
        }

        SemaphoreSlim sessionLock = _locks.GetOrAdd(cacheKey, x => new SemaphoreSlim(1, 1));
        await sessionLock.WaitAsync(cancellationToken);

        try
        {
            // Verify if this is a thread that waited and can now find a smite session
            smiteSessionCacheItem = await _redisCacheProvider.GetAsync<SmiteSessionCacheItem>(cacheKey, cancellationToken);
            if (string.IsNullOrWhiteSpace(smiteSessionCacheItem?.SessionId))
            {
                // While session IDs are valid for 15 minutes, we set it to 10 minutes because we don't want any failures on long running processes
                CreateSmiteSessionDto sessionResponse = await _smiteSessionClient.CreateSmiteSessionAsync(cancellationToken);
                smiteSessionCacheItem = new SmiteSessionCacheItem { SessionId = sessionResponse.SessionId };
                var cacheOptions = new DistributedCacheEntryOptions { AbsoluteExpiration = _timeProvider.GetUtcNow().AddMinutes(10) };
                await _redisCacheProvider.SetAsync(cacheKey, smiteSessionCacheItem, cacheOptions, cancellationToken);
            }
        }
        finally
        {
            sessionLock.Release();
        }

        return smiteSessionCacheItem.SessionId;
    }
}
