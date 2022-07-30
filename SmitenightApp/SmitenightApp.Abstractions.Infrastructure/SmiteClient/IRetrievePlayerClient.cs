using SmitenightApp.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.RetrievePlayerResponses;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface IRetrievePlayerClient
{
    Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerAsync(
        PlayerRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerWithoutPortalAsync(
        PlayerWithoutPortalRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPlayerNameAsync(
        PlayerIdByNameRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPortalUserAsync(
        PlayerIdByPortalUserRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByGamerTagAsync(
        PlayerIdByGamerTagRequest request, CancellationToken cancellationToken);
}