using SmitenightApp.Domain.Clients.RetrievePlayerClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface IRetrievePlayerSmiteClient
{
    Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerAsync(
        string sessionId, string playerId, PortalTypeEnum portalType, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerWithoutPortalAsync(
        string sessionId, string playerName, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPlayerNameAsync(
        string sessionId, string playerName, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPortalUserAsync(
        string sessionId, PortalTypeEnum portalType, string portalUserId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByGamerTagAsync(
        string sessionId, PortalTypeEnum portalType, string gamerTag, CancellationToken cancellationToken = default);
}