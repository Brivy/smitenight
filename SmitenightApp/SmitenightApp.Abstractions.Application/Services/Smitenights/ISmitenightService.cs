namespace SmitenightApp.Abstractions.Application.Services.Smitenights;

public interface ISmitenightService
{
    Task StartSmitenightAsync(string playerName, CancellationToken cancellationToken = default);
    Task EndSmitenightAsync(string playerName, CancellationToken cancellationToken = default);
}