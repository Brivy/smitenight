using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Memory;
using Smitenight.Abstractions.Application.Services.System;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Application.Services.Common;
using Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests;
using Smitenight.Domain.Constants.Common;

namespace Smitenight.Application.Services.System
{
    public class SmiteSessionService : ISmiteSessionService
    {
        private readonly ISystemSmiteClient _systemSmiteClient;
        private readonly IMemoryCache _memoryCache;
        private readonly IClock _clock;

        private readonly ConcurrentDictionary<object, SemaphoreSlim> _locks;

        public SmiteSessionService(ISystemSmiteClient systemSmiteClient,
            IMemoryCache memoryCache,
            IClock clock)
        {
            _systemSmiteClient = systemSmiteClient;
            _memoryCache = memoryCache;
            _clock = clock;
            _locks = new ConcurrentDictionary<object, SemaphoreSlim>();
        }

        /// <summary>
        /// Retrieve the session ID from Smite and store it in the cache
        /// By making use of <see cref="SemaphoreSlim"/>, it will wait when multiple threads try to call the SMITE API at once
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string?> GetSessionIdAsync(CancellationToken cancellationToken = default)
        {
            if (_memoryCache.TryGetValue(CacheKeys.SessionId, out string sessionId))
            {
                return sessionId;
            }

            var sessionLock = _locks.GetOrAdd(CacheKeys.SessionId, x => new SemaphoreSlim(1, 1));
            await sessionLock.WaitAsync(cancellationToken);

            try
            {
                if (!_memoryCache.TryGetValue(CacheKeys.SessionId, out sessionId))
                {
                    var sessionRequest = new CreateSmiteSessionRequest();
                    var sessionResponse = await _systemSmiteClient.CreateSmiteSessionAsync(sessionRequest, cancellationToken);
                    if (sessionResponse?.Response != null)
                    {
                        // While session IDs are valid for 15 minutes, we set it to 10 minutes because we don't want any failures on long running processes
                        sessionId = sessionResponse.Response.SessionId;
                        var cacheOptions = new MemoryCacheEntryOptions { AbsoluteExpiration = _clock.Now().AddMinutes(10) };
                        _memoryCache.Set(CacheKeys.SessionId, sessionId, cacheOptions);
                    }
                }
            }
            finally
            {
                sessionLock.Release();
            }

            return sessionId;
        }
    }
}
