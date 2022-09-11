using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Memory;
using SmitenightApp.Abstractions.Application.System;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.SmiteClient.Requests.SystemRequests;
using SmitenightApp.Domain.Constants.Common;
using SmitenightApp.Domain.Exceptions;

namespace SmitenightApp.Application.System
{
    public class SmiteSessionService : ISmiteSessionService
    {
        private readonly ISessionClient _sessionClient;
        private readonly IMemoryCache _memoryCache;

        private readonly ConcurrentDictionary<object, SemaphoreSlim> _locks;

        public SmiteSessionService(ISessionClient sessionClient,
            IMemoryCache memoryCache)
        {
            _sessionClient = sessionClient;
            _memoryCache = memoryCache;
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
                    var sessionResponse = await _sessionClient.CreateSmiteSessionAsync(sessionRequest, cancellationToken);
                    if (sessionResponse?.Response == null)
                    {
                        throw new SessionCouldNotBeCreatedException();
                    }

                    // While session IDs are valid for 15 minutes, we set it to 10 minutes because we don't want any failures on long running processes
                    sessionId = sessionResponse.Response.SessionId;
                    var cacheOptions = new MemoryCacheEntryOptions { AbsoluteExpiration = DateTime.Now.AddMinutes(10) };
                    _memoryCache.Set(CacheKeys.SessionId, sessionId, cacheOptions);
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
