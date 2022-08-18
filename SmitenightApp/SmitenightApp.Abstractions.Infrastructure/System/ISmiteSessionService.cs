namespace SmitenightApp.Abstractions.Infrastructure.System;

public interface ISmiteSessionService
{
    Task<string> GetSessionIdAsync(CancellationToken cancellationToken = default);
}