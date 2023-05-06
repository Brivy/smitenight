namespace Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;

public interface IMaintainItemsService
{
    Task MaintainAsync(CancellationToken cancellationToken = default);
}