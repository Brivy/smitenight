using Smitenight.Domain.Models.Clients.SystemClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface ISystemSmiteClient
{
    Task<CreateSmiteSession> CreateSmiteSessionAsync(CancellationToken cancellationToken = default);

    Task TestSmiteSessionAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<DataUsed>> GetDataUsedAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<HirezServerStatus>> GetHirezServerStatusAsync(CancellationToken cancellationToken = default);

    Task<PatchInfo> GetPatchInfoAsync(CancellationToken cancellationToken = default);
}