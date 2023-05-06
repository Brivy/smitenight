namespace Smitenight.Application.Blazor.Business.Contracts.Services.Cache;

public interface ISmiteSessionCacheService
{
    Task<string> GetSessionIdAsync(CancellationToken cancellationToken = default);
}