using Smitenight.Domain.Models.Clients.RetrievePlayerClient;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Application.Blazor.Business.Contracts.Facades.SmiteClient;

public interface IRetrievePlayerSmiteClientFacade
{
    Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerAsync(string playerId, PortalTypeEnum portalType, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerWithoutPortalAsync(string playerName, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPlayerNameAsync(string playerName, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPortalUserAsync(PortalTypeEnum portalType, string portalUserId, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByGamerTagAsync(PortalTypeEnum portalType, string gamerTag, CancellationToken cancellationToken = default);
}