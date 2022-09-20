using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Clients.SystemClient;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

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