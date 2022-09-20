using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Distributed;
using SmitenightApp.Abstractions.Application.Services.Cache;
using SmitenightApp.Abstractions.Infrastructure.RedisCache.Providers;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Cache;
using SmitenightApp.Domain.Constants.Common;
using SmitenightApp.Domain.Exceptions;

namespace SmitenightApp.Application.Services.Cache
{
    public class SmiteSessionCacheService : ISmiteSessionCacheService
    {
        private readonly ISystemSmiteClient _systemSmiteClient;
        private readonly IRedisCacheProvider _redisCacheProvider;

        private readonly ConcurrentDictionary<object, SemaphoreSlim> _locks;

        public SmiteSessionCacheService(
            ISystemSmiteClient systemSmiteClient,
            IRedisCacheProvider redisCacheProvider)
        {
            _systemSmiteClient = systemSmiteClient;
            _redisCacheProvider = redisCacheProvider;
            _locks = new ConcurrentDictionary<object, SemaphoreSlim>();
        }

        /// <summary>
        /// Retrieve the session ID from Smite and store it in the cache
        /// By making use of <see cref="SemaphoreSlim"/>, it will wait when multiple threads try to call the SMITE API at once
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> GetSessionIdAsync(CancellationToken cancellationToken = default)
        {
            var cacheKey = _redisCacheProvider.GenerateCacheKey(CacheKeys.SmiteSessionCacheKey);
            var smiteSessionCacheItem = await _redisCacheProvider.GetAsync<SmiteSessionCacheItem>(cacheKey, cancellationToken);
            if (!string.IsNullOrWhiteSpace(smiteSessionCacheItem?.SessionId))
            {
                return smiteSessionCacheItem.SessionId;
            }

            var sessionLock = _locks.GetOrAdd(cacheKey, x => new SemaphoreSlim(1, 1));
            await sessionLock.WaitAsync(cancellationToken);

            try
            {
                // Verify if this is a thread that waited and can now find a smite session
                smiteSessionCacheItem = await _redisCacheProvider.GetAsync<SmiteSessionCacheItem>(cacheKey, cancellationToken);
                if (string.IsNullOrWhiteSpace(smiteSessionCacheItem?.SessionId))
                {
                    var sessionResponse = await _systemSmiteClient.CreateSmiteSessionAsync(cancellationToken);
                    if (sessionResponse?.Response == null)
                    {
                        throw new SessionCouldNotBeCreatedException();
                    }

                    // While session IDs are valid for 15 minutes, we set it to 10 minutes because we don't want any failures on long running processes
                    smiteSessionCacheItem = new SmiteSessionCacheItem { SessionId = sessionResponse.Response.SessionId };
                    var cacheOptions = new DistributedCacheEntryOptions { AbsoluteExpiration = DateTime.Now.AddMinutes(10) };
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
}
