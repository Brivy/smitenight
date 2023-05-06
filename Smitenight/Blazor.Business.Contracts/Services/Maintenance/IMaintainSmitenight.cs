namespace Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;

public interface IMaintainSmitenight
{
    Task MaintainAsync(CancellationToken cancellationToken = default);
}