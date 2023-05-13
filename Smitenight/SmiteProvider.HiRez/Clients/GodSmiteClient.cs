﻿using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Services;
using Smitenight.Utilities.Mapper.Common.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class GodSmiteClient : SmiteClient, IGodSmiteClient
    {
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapperService _mapperService;

        public GodSmiteClient(HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapperService mapperService) : base(httpClient)
        {
            _smiteClientUrlService = smiteClientUrlService;
            _mapperService = mapperService;
        }

        public async Task<IEnumerable<GodDto>> GetGodsAsync(LanguageCode languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)languageCode);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<God>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<God>, IEnumerable<GodDto>>(result);
        }

        public async Task<IEnumerable<GodLeaderbordDto>> GetGodLeaderbordAsync(int godId, GameModeQueue gameModeQueue, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(godId, (int)gameModeQueue);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodLeaderboardMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<GodLeaderbord>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<GodLeaderbord>, IEnumerable<GodLeaderbordDto>>(result);
        }

        public async Task<IEnumerable<GodAltAbilityDto>> GetGodAltAbilitiesAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodAltAbilitiesMethod, cancellationToken);
            var result = await GetAsync<IEnumerable<GodAltAbility>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<GodAltAbility>, IEnumerable<GodAltAbilityDto>>(result);
        }

        public async Task<IEnumerable<GodSkinDto>> GetGodSkinsAsync(int godId, LanguageCode languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(godId, (int)languageCode);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodSkinsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<GodSkin>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<GodSkin>, IEnumerable<GodSkinDto>>(result);
        }
    }
}
