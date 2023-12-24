using Microsoft.Extensions.Caching.Distributed;

namespace Smitenight.Utilities.Cache.Contracts.Providers;

public interface IRedisCacheProvider
{
    string GenerateCacheKey(string key);
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);
    Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default);
    Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions options, CancellationToken cancellationToken = default);
    Task DeleteAsync(string key, CancellationToken cancellationToken = default);
}
