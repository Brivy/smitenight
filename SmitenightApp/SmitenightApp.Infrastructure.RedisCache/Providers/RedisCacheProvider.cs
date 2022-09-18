using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Infrastructure.RedisCache.Providers;
using SmitenightApp.Infrastructure.RedisCache.Settings;

namespace SmitenightApp.Infrastructure.RedisCache.Providers
{
    public class RedisCacheProvider : IRedisCacheProvider
    {
        private readonly IDistributedCache _distributedCache;
        private readonly RedisCacheSettings _redisCacheSettings;
        private readonly ILogger<RedisCacheProvider> _logger;

        public RedisCacheProvider(
            IDistributedCache distributedCache,
            IOptions<RedisCacheSettings> redisCacheSettings,
            ILogger<RedisCacheProvider> logger)
        {
            _distributedCache = distributedCache;
            _redisCacheSettings = redisCacheSettings.Value;
            _logger = logger;
        }

        public string GenerateCacheKey(string key)
        {
            return $"{_redisCacheSettings.EnvironmentPrefix}-{key}";
        }

        public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
        {
            try
            {
                var value = await _distributedCache.GetStringAsync(key, cancellationToken);
                if (value != null)
                {
                    try
                    {
                        return JsonSerializer.Deserialize<T>(value);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Could not deserialize the cache object with the following key: '{key}' and value: '{value}'");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not read cache with the following key: '{key}'");
            }

            return default;
        }

        public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default) =>
            await SetAsync(key, value, new DistributedCacheEntryOptions(), cancellationToken);

        public async Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions options, CancellationToken cancellationToken = default)
        {
            if (value == null)
            {
                return;
            }

            try
            {
                var serializedValue = JsonSerializer.Serialize(value);
                try
                {
                    await _distributedCache.SetStringAsync(key, serializedValue, options, cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Could not write the serialized value '{serializedValue}' to the cache with the key: '{key}'");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not serialize the value: '{value}' to the cache with the key '{key}'");
            }
        }

        public async Task DeleteAsync(string key, CancellationToken cancellationToken = default)
        {
            try
            {
                await _distributedCache.RemoveAsync(key, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not delete the cache object with the key '{key}'");
            }
        }
    }
}
