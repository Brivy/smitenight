namespace Smitenight.Application.Core.Business.Contracts.Services.Maintenance;

public interface IMaintainPatchesService
{
    Task MaintainPatchAsync(string version, CancellationToken cancellationToken = default);
}
