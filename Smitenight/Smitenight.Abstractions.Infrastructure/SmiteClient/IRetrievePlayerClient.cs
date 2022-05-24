using Smitenight.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.RetrievePlayerResponses;

namespace Smitenight.Abstractions.Infrastructure.SmiteClient;

public interface IRetrievePlayerClient
{
    Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerAsync(
        PlayerRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerWithoutPortalAsync(
        PlayerWithoutPortalRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPlayerNameAsync(
        PlayerIdByPlayerNameRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPortalUserAsync(
        PlayerIdByPortalUserRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByGamerTagAsync(
        PlayerIdByGamerTagRequest request, CancellationToken cancellationToken);
}