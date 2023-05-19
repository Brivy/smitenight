using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.RetrievePlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.RetrievePlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Services;
using Smitenight.Utilities.Mapper.Common.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class RetrievePlayerSmiteClient : SmiteClient, IRetrievePlayerSmiteClient
    {
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapperService _mapperService;

        public RetrievePlayerSmiteClient(HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapperService mapperService) : base(httpClient)
        {
            _smiteClientUrlService = smiteClientUrlService;
            _mapperService = mapperService;
        }

        public async Task<IEnumerable<PlayerDto>> GetPlayerAsync(string playerId, PortalType portalType, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId, (int)portalType);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<Player>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<Player>, IEnumerable<PlayerDto>>(result);
        }

        public async Task<IEnumerable<PlayerDto>> GetPlayerWithoutPortalAsync(string playerName, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerName);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<Player>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<Player>, IEnumerable<PlayerDto>>(result);
        }

        public async Task<IEnumerable<PlayerIdDto>> GetPlayerIdByPlayerNameAsync(string playerName, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerName);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerIdByNameMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<PlayerId>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<PlayerId>, IEnumerable<PlayerIdDto>>(result);
        }

        public async Task<IEnumerable<PlayerIdDto>> GetPlayerIdByPortalUserAsync(PortalType portalType, string portalUserId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)portalType, portalUserId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerIdByPortalUserIdMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<PlayerId>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<PlayerId>, IEnumerable<PlayerIdDto>>(result);
        }

        public async Task<IEnumerable<PlayerIdDto>> GetPlayerIdByGamerTagAsync(PortalType portalType, string gamerTag, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)portalType, gamerTag);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerIdByGamerTagMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<PlayerId>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<PlayerId>, IEnumerable<PlayerIdDto>>(result);
        }
    }
}
