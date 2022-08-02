using SmitenightApp.Domain.Clients.SmiteClient.Requests.SystemRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.SystemResponses;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface ISystemSmiteClient
{
    Task<SmiteClientResponse?> TestSmiteSessionAsync(
        TestSmiteSessionRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<DataUsedResponse>?> GetDataUsedAsync(
        DataUsedRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<HirezServerStatusResponse>?> GetHirezServerStatusAsync(
        HirezServerStatusRequest request, CancellationToken cancellationToken);

    Task<SmiteClientResponse<PatchInfoResponse>?> GetPatchInfoAsync(
        PatchInfoRequest request, CancellationToken cancellationToken);
}