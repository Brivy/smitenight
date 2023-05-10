using AutoMapper;
using Smitenight.Domain.Models.Clients.RetrievePlayerClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Responses.RetrievePlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class RetrievePlayerSmiteClient : SmiteClient, IRetrievePlayerSmiteClient
    {
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapper _mapper;

        public RetrievePlayerSmiteClient(HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapper mapper) : base(httpClient)
        {
            _smiteClientUrlService = smiteClientUrlService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Player>> GetPlayerAsync(string playerId, PortalTypeEnum portalType, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerId, (int)portalType);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<PlayerResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<Player>>(result);
        }

        public async Task<IEnumerable<Player>> GetPlayerWithoutPortalAsync(string playerName, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerName);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<PlayerResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<Player>>(result);
        }

        public async Task<IEnumerable<PlayerId>> GetPlayerIdByPlayerNameAsync(string playerName, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(playerName);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerIdByNameMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<PlayerIdResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<PlayerId>>(result);
        }

        public async Task<IEnumerable<PlayerId>> GetPlayerIdByPortalUserAsync(PortalTypeEnum portalType, string portalUserId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)portalType, portalUserId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerIdByPortalUserIdMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<PlayerIdResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<PlayerId>>(result);
        }

        public async Task<IEnumerable<PlayerId>> GetPlayerIdByGamerTagAsync(PortalTypeEnum portalType, string gamerTag, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)portalType, gamerTag);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerIdByGamerTagMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<PlayerIdResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<PlayerId>>(result);
        }
    }
}
