using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.SystemResponses;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface ISystemSmiteClient
{
    Task<SmiteClientResponse?> TestSmiteSessionAsync(
        string sessionId, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<DataUsedResponse>?> GetDataUsedAsync(
        string sessionId, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<HirezServerStatusResponse>?> GetHirezServerStatusAsync(
        string sessionId, CancellationToken cancellationToken);

    Task<SmiteClientResponse<PatchInfoResponse>?> GetPatchInfoAsync(
        string sessionId, CancellationToken cancellationToken);
}