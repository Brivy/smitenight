using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.RetrievePlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.RetrievePlayerClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients;

public partial class SmiteClient
{
    public async Task<IEnumerable<PlayerDto>> GetPlayerAsync(string playerId, PortalType portalType, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(playerId, (int)portalType);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerMethod, urlPath, cancellationToken);
        IEnumerable<Player> result = await GetAsync<IEnumerable<Player>>(url, cancellationToken);
        return _mapperService.MapAll<Player, PlayerDto>(result);
    }

    public async Task<IEnumerable<PlayerDto>> GetPlayerWithoutPortalAsync(string playerName, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(playerName);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerMethod, urlPath, cancellationToken);
        IEnumerable<Player> result = await GetAsync<IEnumerable<Player>>(url, cancellationToken);
        return _mapperService.MapAll<Player, PlayerDto>(result);
    }

    public async Task<IEnumerable<PlayerIdDto>> GetPlayerIdByPlayerNameAsync(string playerName, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(playerName);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerIdByNameMethod, urlPath, cancellationToken);
        IEnumerable<PlayerId> result = await GetAsync<IEnumerable<PlayerId>>(url, cancellationToken);
        return _mapperService.MapAll<PlayerId, PlayerIdDto>(result);
    }

    public async Task<IEnumerable<PlayerIdDto>> GetPlayerIdByPortalUserAsync(PortalType portalType, string portalUserId, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath((int)portalType, portalUserId);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerIdByPortalUserIdMethod, urlPath, cancellationToken);
        IEnumerable<PlayerId> result = await GetAsync<IEnumerable<PlayerId>>(url, cancellationToken);
        return _mapperService.MapAll<PlayerId, PlayerIdDto>(result);
    }

    public async Task<IEnumerable<PlayerIdDto>> GetPlayerIdByGamerTagAsync(PortalType portalType, string gamerTag, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath((int)portalType, gamerTag);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerIdByGamerTagMethod, urlPath, cancellationToken);
        IEnumerable<PlayerId> result = await GetAsync<IEnumerable<PlayerId>>(url, cancellationToken);
        return _mapperService.MapAll<PlayerId, PlayerIdDto>(result);
    }
}
