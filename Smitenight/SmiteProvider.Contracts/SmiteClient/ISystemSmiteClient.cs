using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Clients.SystemClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;

public interface ISystemSmiteClient
{
    Task<SmiteClientResponse<CreateSmiteSessionResponse>?> CreateSmiteSessionAsync(
        CancellationToken cancellationToken = default);

    Task<SmiteClientResponse?> TestSmiteSessionAsync(
        string sessionId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<DataUsedResponse>?> GetDataUsedAsync(
        string sessionId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<HirezServerStatusResponse>?> GetHirezServerStatusAsync(
        string sessionId, CancellationToken cancellationToken = default);

    Task<SmiteClientResponse<PatchInfoResponse>?> GetPatchInfoAsync(
        string sessionId, CancellationToken cancellationToken = default);
}