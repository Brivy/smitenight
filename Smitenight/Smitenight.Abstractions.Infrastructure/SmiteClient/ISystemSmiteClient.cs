using Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.SystemResponses;

namespace Smitenight.Abstractions.Infrastructure.SmiteClient;

public interface ISystemSmiteClient
{
    Task<SmiteClientResponse?> PingHirezAsync(
        PingHirezRequest pingHirezRequest, CancellationToken cancellationToken);

    Task<SmiteClientResponse<CreateSmiteSessionResponse>?> CreateSmiteSessionAsync(
        CreateSmiteSessionRequest createSmiteSessionRequest, CancellationToken cancellationToken);

    Task<SmiteClientResponse?> TestSmiteSessionAsync(
        TestSmiteSessionRequest testSmiteSessionRequest, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<DataUsedResponse>?> GetDataUsedAsync(
        DataUsedRequest dataUsedRequest, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<HirezServerStatusResponse>?> GetHirezServerStatusAsync(
        HirezServerStatusRequest hirezServerStatusRequest, CancellationToken cancellationToken);

    Task<SmiteClientResponse<PatchInfoResponse>?> GetPatchInfoAsync(
        PatchInfoRequest patchInfoRequest, CancellationToken cancellationToken);
}