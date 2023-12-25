namespace Smitenight.Application.Core.Business.Contracts.Services.Maintenance;

public interface IMaintainSmitenight
{
    Task MaintainPatchesAsync(CancellationToken cancellationToken = default);
    Task MaintainGodsAsync(CancellationToken cancellationToken = default);
    Task MaintainItemsAsync(CancellationToken cancellationToken = default);
}
