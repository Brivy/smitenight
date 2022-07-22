namespace Smitenight.Abstractions.Application.Services.Maintenance;

public interface IMaintainGodsService
{
    Task MaintainAsync(string sessionId, CancellationToken cancellationToken = default);
}