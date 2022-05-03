using Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.SystemResponses;

namespace Smitenight.Abstractions.Infrastructure.SmiteClient;

public interface ISystemSmiteClient
{
    Task<SmiteClientResponseModel?> PingHirezAsync(
        PingHirezRequest pingHirezRequest, CancellationToken cancellationToken);

    Task<CreateSmiteSessionResponseModel?> CreateSmiteSessionAsync(
        CreateSmiteSessionRequest createSmiteSessionRequest, CancellationToken cancellationToken);

    Task<SmiteClientResponseModel?> TestSmiteSessionAsync(
        TestSmiteSessionRequest testSmiteSessionRequest, CancellationToken cancellationToken);
}