namespace SmitenightApp.Abstractions.Application.Services.Cache;

public interface ISmiteSessionCacheService
{
    Task<string> GetSessionIdAsync(CancellationToken cancellationToken = default);
}