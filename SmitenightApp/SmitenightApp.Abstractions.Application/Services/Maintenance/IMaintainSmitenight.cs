namespace SmitenightApp.Abstractions.Application.Services.Maintenance;

public interface IMaintainSmitenight
{
    Task MaintainAsync(CancellationToken cancellationToken = default);
}