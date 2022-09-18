using SmitenightApp.Domain.Clients.RetrievePlayerClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Abstractions.Application.Facades.SmiteClient;

public interface IRetrievePlayerSmiteClientFacade
{
    Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerAsync(string playerId, PortalTypeEnum portalType, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerWithoutPortalAsync(string playerName, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPlayerNameAsync(string playerName, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPortalUserAsync(PortalTypeEnum portalType, string portalUserId, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByGamerTagAsync(PortalTypeEnum portalType, string gamerTag, CancellationToken cancellationToken = default);
}