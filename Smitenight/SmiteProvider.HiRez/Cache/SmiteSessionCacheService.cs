﻿using Microsoft.Extensions.Caching.Distributed;
using Smitenight.Domain.Models.Cache;
using Smitenight.Domain.Models.Constants.Common;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Utilities.Cache.Contracts.Providers;
using System.Collections.Concurrent;

namespace Smitenight.Application.Blazor.Business.Services.Cache
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
                    // While session IDs are valid for 15 minutes, we set it to 10 minutes because we don't want any failures on long running processes
                    var sessionResponse = await _systemSmiteClient.CreateSmiteSessionAsync(cancellationToken);
                    smiteSessionCacheItem = new SmiteSessionCacheItem { SessionId = sessionResponse.SessionId };
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