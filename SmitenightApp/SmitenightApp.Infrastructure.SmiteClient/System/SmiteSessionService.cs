using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Distributed;
using SmitenightApp.Abstractions.Application.System;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Constants.Common;
using SmitenightApp.Domain.Exceptions;

namespace SmitenightApp.Infrastructure.SmiteClient.System
{
    public class SmiteSessionService : ISmiteSessionService
    {
        private readonly ISessionClient _sessionClient;
        private readonly IDistributedCache _distributedCache;

        private readonly ConcurrentDictionary<object, SemaphoreSlim> _locks;

        public SmiteSessionService(ISessionClient sessionClient,
            IDistributedCache distributedCache)
        {
            _sessionClient = sessionClient;
            _distributedCache = distributedCache;
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
            var sessionId = await _distributedCache.GetStringAsync(CacheKeys.SessionId, cancellationToken);
            if (!string.IsNullOrWhiteSpace(sessionId))
            {
                return sessionId;
            }

            var sessionLock = _locks.GetOrAdd(CacheKeys.SessionId, x => new SemaphoreSlim(1, 1));
            await sessionLock.WaitAsync(cancellationToken);

            try
            {
                sessionId = await _distributedCache.GetStringAsync(CacheKeys.SessionId, cancellationToken);
                if (string.IsNullOrWhiteSpace(sessionId))
                {
                    var sessionResponse = await _sessionClient.CreateSmiteSessionAsync(cancellationToken);
                    if (sessionResponse?.Response == null)
                    {
                        throw new SessionCouldNotBeCreatedException();
                    }

                    // While session IDs are valid for 15 minutes, we set it to 10 minutes because we don't want any failures on long running processes
                    sessionId = sessionResponse.Response.SessionId;
                    var cacheOptions = new DistributedCacheEntryOptions { AbsoluteExpiration = DateTime.Now.AddMinutes(10) };
                    await _distributedCache.SetStringAsync(CacheKeys.SessionId, sessionId, cacheOptions, cancellationToken);
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
