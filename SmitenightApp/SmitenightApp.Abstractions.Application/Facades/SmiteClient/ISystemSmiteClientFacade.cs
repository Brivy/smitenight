using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Clients.SystemClient;

namespace SmitenightApp.Abstractions.Application.Facades.SmiteClient;

public interface ISystemSmiteClientFacade
{
    Task<SmiteClientResponse?> TestSmiteSessionAsync(CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<DataUsedResponse>?> GetDataUsedAsync(CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<HirezServerStatusResponse>?> GetHirezServerStatusAsync(CancellationToken cancellationToken = default);
    Task<SmiteClientResponse<PatchInfoResponse>?> GetPatchInfoAsync(CancellationToken cancellationToken = default);
}