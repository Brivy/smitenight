using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Clients.SystemClient;

namespace Smitenight.Application.Blazor.Business.Contracts.Facades.SmiteClient;

public interface ISystemSmiteClientFacade
{
    Task<SmiteClientResponse?> TestSmiteSessionAsync(CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<DataUsedResponse>?> GetDataUsedAsync(CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<HirezServerStatusResponse>?> GetHirezServerStatusAsync(CancellationToken cancellationToken = default);
    Task<SmiteClientResponse<PatchInfoResponse>?> GetPatchInfoAsync(CancellationToken cancellationToken = default);
}