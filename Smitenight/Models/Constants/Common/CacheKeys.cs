using Smitenight.Domain.Models.Cache;

namespace Smitenight.Domain.Models.Constants.Common
{
    public static class CacheKeys
    {
        /// <summary>
        /// Cache key that should be used for <see cref="SmiteSessionCacheItem"/>
        /// </summary>
        public const string SmiteSessionCacheKey = nameof(SmiteSessionCacheKey);
    }
}
