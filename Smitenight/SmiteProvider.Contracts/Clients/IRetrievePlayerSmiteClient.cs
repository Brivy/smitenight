using Smitenight.Domain.Models.Clients.RetrievePlayerClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface IRetrievePlayerSmiteClient
{
    Task<IEnumerable<PlayerDto>> GetPlayerAsync(string playerId, PortalTypeEnum portalType, CancellationToken cancellationToken = default);

    Task<IEnumerable<PlayerDto>> GetPlayerWithoutPortalAsync(string playerName, CancellationToken cancellationToken = default);

    Task<IEnumerable<PlayerIdDto>> GetPlayerIdByPlayerNameAsync(string playerName, CancellationToken cancellationToken = default);

    Task<IEnumerable<PlayerIdDto>> GetPlayerIdByPortalUserAsync(PortalTypeEnum portalType, string portalUserId, CancellationToken cancellationToken = default);

    Task<IEnumerable<PlayerIdDto>> GetPlayerIdByGamerTagAsync(PortalTypeEnum portalType, string gamerTag, CancellationToken cancellationToken = default);
}