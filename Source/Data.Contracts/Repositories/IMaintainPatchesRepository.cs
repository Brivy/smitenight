using Smitenight.Persistence.Data.Contracts.Models;

namespace Smitenight.Persistence.Data.Contracts.Repositories
{
    public interface IMaintainPatchesRepository
    {
        Task<int> GetLatestPatchAsync(CancellationToken cancellationToken = default);
        Task<bool> IsNewVersionAsync(string version, CancellationToken cancellationToken = default);
        Task CreatePatchAsync(CreatePatchDto patch, CancellationToken cancellationToken = default);
    }
}