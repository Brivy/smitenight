using Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.SystemResponses;

namespace Smitenight.Abstractions.Infrastructure.SmiteClient;

public interface ISystemSmiteClient
{
    Task<SmiteClientResponse<CreateSmiteSessionResponse>?> CreateSmiteSessionAsync(
        CreateSmiteSessionRequest request, CancellationToken cancellationToken);

    Task<SmiteClientResponse?> TestSmiteSessionAsync(
        TestSmiteSessionRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<DataUsedResponse>?> GetDataUsedAsync(
        DataUsedRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<HirezServerStatusResponse>?> GetHirezServerStatusAsync(
        HirezServerStatusRequest request, CancellationToken cancellationToken);

    Task<SmiteClientResponse<PatchInfoResponse>?> GetPatchInfoAsync(
        PatchInfoRequest request, CancellationToken cancellationToken);
}