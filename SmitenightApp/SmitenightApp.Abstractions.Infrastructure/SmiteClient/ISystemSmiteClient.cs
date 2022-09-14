using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.SystemResponses;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface ISystemSmiteClient
{
    Task<SmiteClientResponse?> TestSmiteSessionAsync(
        CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<DataUsedResponse>?> GetDataUsedAsync(
        CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<HirezServerStatusResponse>?> GetHirezServerStatusAsync(
        CancellationToken cancellationToken = default);

    Task<SmiteClientResponse<PatchInfoResponse>?> GetPatchInfoAsync(
        CancellationToken cancellationToken = default);
}