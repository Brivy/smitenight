using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public partial class SmiteClient
    {
        public async Task<IEnumerable<GodDto>> GetGodsAsync(LanguageCode languageCode, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath((int)languageCode);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<God>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<God>, IEnumerable<GodDto>>(result);
        }

        public async Task<IEnumerable<GodLeaderboardDto>> GetGodLeaderboardAsync(int godId, GameModeQueue gameModeQueue, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(godId, (int)gameModeQueue);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodLeaderboardMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<GodLeaderboard>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<GodLeaderboard>, IEnumerable<GodLeaderboardDto>>(result);
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
