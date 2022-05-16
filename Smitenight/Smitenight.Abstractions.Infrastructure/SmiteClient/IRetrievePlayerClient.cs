using Smitenight.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.RetrievePlayerResponses;

namespace Smitenight.Abstractions.Infrastructure.SmiteClient;

public interface IRetrievePlayerClient
{
    Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerAsync(
        PlayerRequest playerRequest, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerWithoutPortalAsync(
        PlayerWithoutPortalRequest playerWithoutPortalRequest, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPlayerNameAsync(
        PlayerIdByPlayerNameRequest playerIdByPlayerNameRequest, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPortalUserAsync(
        PlayerIdByPortalUserRequest playerIdByPortalUserRequest, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByGamerTagAsync(
        PlayerIdByGamerTagRequest playerIdByGamerTagRequest, CancellationToken cancellationToken);
}