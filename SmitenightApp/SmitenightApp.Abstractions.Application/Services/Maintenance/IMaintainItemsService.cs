namespace SmitenightApp.Abstractions.Application.Services.Maintenance;

public interface IMaintainItemsService
{
    Task MaintainAsync(string sessionId, CancellationToken cancellationToken = default);
}