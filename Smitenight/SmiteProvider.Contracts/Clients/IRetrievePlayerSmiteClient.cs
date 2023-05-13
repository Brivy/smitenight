using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.RetrievePlayerClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface IRetrievePlayerSmiteClient
{
    Task<IEnumerable<PlayerDto>> GetPlayerAsync(string playerId, PortalType portalType, CancellationToken cancellationToken = default);

    Task<IEnumerable<PlayerDto>> GetPlayerWithoutPortalAsync(string playerName, CancellationToken cancellationToken = default);

    Task<IEnumerable<PlayerIdDto>> GetPlayerIdByPlayerNameAsync(string playerName, CancellationToken cancellationToken = default);

    Task<IEnumerable<PlayerIdDto>> GetPlayerIdByPortalUserAsync(PortalType portalType, string portalUserId, CancellationToken cancellationToken = default);

    Task<IEnumerable<PlayerIdDto>> GetPlayerIdByGamerTagAsync(PortalType portalType, string gamerTag, CancellationToken cancellationToken = default);
}