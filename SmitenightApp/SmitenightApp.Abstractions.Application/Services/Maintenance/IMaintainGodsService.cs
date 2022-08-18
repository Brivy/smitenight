namespace SmitenightApp.Abstractions.Application.Services.Maintenance;

public interface IMaintainGodsService
{
    Task MaintainAsync(CancellationToken cancellationToken = default);
}