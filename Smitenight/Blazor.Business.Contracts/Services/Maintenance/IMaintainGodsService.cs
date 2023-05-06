namespace Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;

public interface IMaintainGodsService
{
    Task MaintainAsync(CancellationToken cancellationToken = default);
}