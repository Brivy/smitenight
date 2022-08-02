namespace SmitenightApp.Abstractions.Application.Services.Maintenance;

public interface IMaintainItemsService
{
    Task MaintainAsync(CancellationToken cancellationToken = default);
}