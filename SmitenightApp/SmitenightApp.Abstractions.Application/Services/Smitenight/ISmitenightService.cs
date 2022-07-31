namespace SmitenightApp.Abstractions.Application.Services.Smitenight;

public interface ISmitenightService
{
    Task StartSmitenight(string playerName, CancellationToken cancellationToken = default);
    Task EndSmitenight(string playerName, CancellationToken cancellationToken = default);
}