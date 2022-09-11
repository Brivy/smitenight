using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.RetrievePlayerResponses;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface IRetrievePlayerClient
{
    Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerAsync(
        string sessionId, string playerId, PortalTypeEnum portalType, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerWithoutPortalAsync(
        string sessionId, string playerName, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPlayerNameAsync(
        string sessionId, string playerName, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPortalUserAsync(
        string sessionId, PortalTypeEnum portalType, string portalUserId, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByGamerTagAsync(
        string sessionId, PortalTypeEnum portalType, string gamerTag, CancellationToken cancellationToken);
}