namespace Smitenight.Application.Blazor.Business.Contracts.Services.Matches;

public interface IImportMatchService
{
    Task<int?> ImportAsync(int smiteMatchId, CancellationToken cancellationToken = default);
    Task<List<int>> ImportAsync(List<int> smiteMatchIds, CancellationToken cancellationToken = default);
}