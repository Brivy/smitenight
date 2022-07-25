namespace Smitenight.Abstractions.Application.Services.System;

public interface ISmiteSessionService
{
    Task<string?> GetSessionIdAsync(CancellationToken cancellationToken = default);
}