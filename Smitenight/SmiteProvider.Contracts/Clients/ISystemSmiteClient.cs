using Smitenight.Domain.Models.Clients.SystemClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface ISystemSmiteClient
{
    Task<CreateSmiteSessionDto> CreateSmiteSessionAsync(CancellationToken cancellationToken = default);

    Task TestSmiteSessionAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<DataUsedDto>> GetDataUsedAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<HirezServerStatusDto>> GetHirezServerStatusAsync(CancellationToken cancellationToken = default);

    Task<PatchInfoDto> GetPatchInfoAsync(CancellationToken cancellationToken = default);
}