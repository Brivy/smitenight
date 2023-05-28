using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.RetrievePlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.RetrievePlayerClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public partial class SmiteClient
    {
        public async Task<IEnumerable<PlayerDto>> GetPlayerAsync(string playerId, PortalType portalType, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId, (int)portalType);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<Player>>(url, cancellationToken);
            return _mapperService.MapAll<Player, PlayerDto>(result);
        }

        public async Task<IEnumerable<PlayerDto>> GetPlayerWithoutPortalAsync(string playerName, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerName);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<Player>>(url, cancellationToken);
            return _mapperService.MapAll<Player, PlayerDto>(result);
        }

        public async Task<IEnumerable<PlayerIdDto>> GetPlayerIdByPlayerNameAsync(string playerName, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerName);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerIdByNameMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<PlayerId>>(url, cancellationToken);
            return _mapperService.MapAll<PlayerId, PlayerIdDto>(result);
        }

        public async Task<IEnumerable<PlayerIdDto>> GetPlayerIdByPortalUserAsync(PortalType portalType, string portalUserId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)portalType, portalUserId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerIdByPortalUserIdMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<PlayerId>>(url, cancellationToken);
            return _mapperService.MapAll<PlayerId, PlayerIdDto>(result);
        }

        public async Task<IEnumerable<PlayerIdDto>> GetPlayerIdByGamerTagAsync(PortalType portalType, string gamerTag, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)portalType, gamerTag);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerIdByGamerTagMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<PlayerId>>(url, cancellationToken);
            return _mapperService.MapAll<PlayerId, PlayerIdDto>(result);
        }
    }
}
