namespace Smitenight.Application.Blazor.Business.Services.Cache
{
    public interface ISmiteSessionCacheService
    {
        Task<string> GetSessionIdAsync(CancellationToken cancellationToken = default);
    }
}