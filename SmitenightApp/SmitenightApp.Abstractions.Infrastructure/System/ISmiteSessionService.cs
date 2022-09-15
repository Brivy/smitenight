namespace SmitenightApp.Abstractions.Application.System;

public interface ISmiteSessionService
{
    Task<string> GetSessionIdAsync(CancellationToken cancellationToken = default);
}