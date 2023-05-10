using Smitenight.Domain.Models.Clients.RetrievePlayerClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface IRetrievePlayerSmiteClient
{
    Task<IEnumerable<Player>> GetPlayerAsync(string playerId, PortalTypeEnum portalType, CancellationToken cancellationToken = default);

    Task<IEnumerable<Player>> GetPlayerWithoutPortalAsync(string playerName, CancellationToken cancellationToken = default);

    Task<IEnumerable<PlayerId>> GetPlayerIdByPlayerNameAsync(string playerName, CancellationToken cancellationToken = default);

    Task<IEnumerable<PlayerId>> GetPlayerIdByPortalUserAsync(PortalTypeEnum portalType, string portalUserId, CancellationToken cancellationToken = default);

    Task<IEnumerable<PlayerId>> GetPlayerIdByGamerTagAsync(PortalTypeEnum portalType, string gamerTag, CancellationToken cancellationToken = default);
}