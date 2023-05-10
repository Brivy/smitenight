using AutoMapper;
using Smitenight.Domain.Models.Clients.GodClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Responses.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class GodSmiteClient : SmiteClient, IGodSmiteClient
    {
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapper _mapper;

        public GodSmiteClient(HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapper mapper) : base(httpClient)
        {
            _smiteClientUrlService = smiteClientUrlService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<God>> GetGodsAsync(LanguageCodeEnum languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)languageCode);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<GodsResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<God>>(result);
        }

        public async Task<IEnumerable<GodLeaderbord>> GetGodLeaderbordAsync(int godId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(godId, (int)gameModeQueueId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodLeaderboardMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<GodLeaderbordResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<GodLeaderbord>>(result);
        }

        public async Task<IEnumerable<GodAltAbility>> GetGodAltAbilitiesAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodAltAbilitiesMethod, cancellationToken);
            var result = await GetAsync<IEnumerable<GodAltAbilitiesResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<GodAltAbility>>(result);
        }

        public async Task<IEnumerable<GodSkin>> GetGodSkinsAsync(int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(godId, (int)languageCode);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodSkinsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<GodSkinsResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<GodSkin>>(result);
        }
    }
}
