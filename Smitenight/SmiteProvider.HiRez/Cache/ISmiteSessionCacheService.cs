namespace Smitenight.Providers.SmiteProvider.HiRez.Cache
{
    public interface ISmiteSessionCacheService
    {
        Task<string> GetSessionIdAsync(CancellationToken cancellationToken = default);
    }
}