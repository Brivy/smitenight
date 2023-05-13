namespace Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;

public interface IMaintainSmitenight
{
    Task MaintainGodsAsync(CancellationToken cancellationToken = default);
    Task MaintainItemsAsync(CancellationToken cancellationToken = default);
}