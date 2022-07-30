namespace SmitenightApp.Abstractions.Application.Services.Matches;

public interface IImportMatchService
{
    Task ImportAsync(int smiteMatchId, CancellationToken cancellationToken = default);
}