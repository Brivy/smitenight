﻿using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients;

public partial class SmiteClient
{
    public async Task<IEnumerable<GodDto>> GetGodsAsync(LanguageCode languageCode, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath((int)languageCode);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodsMethod, urlPath, cancellationToken);
        IEnumerable<God> result = await GetAsync<IEnumerable<God>>(url, cancellationToken);
        return _mapperService.MapAll<God, GodDto>(result);
    }

    public async Task<IEnumerable<GodLeaderboardDto>> GetGodLeaderboardAsync(int godId, GameModeQueue gameModeQueue, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(godId, (int)gameModeQueue);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodLeaderboardMethod, urlPath, cancellationToken);
        IEnumerable<GodLeaderboard> result = await GetAsync<IEnumerable<GodLeaderboard>>(url, cancellationToken);
        return _mapperService.MapAll<GodLeaderboard, GodLeaderboardDto>(result);
    }

    public async Task<IEnumerable<GodAltAbilityDto>> GetGodAltAbilitiesAsync(CancellationToken cancellationToken = default)
    {
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodAltAbilitiesMethod, cancellationToken);
        IEnumerable<GodAltAbility> result = await GetAsync<IEnumerable<GodAltAbility>>(url, cancellationToken);
        return _mapperService.MapAll<GodAltAbility, GodAltAbilityDto>(result);
    }

    public async Task<IEnumerable<GodSkinDto>> GetGodSkinsAsync(int godId, LanguageCode languageCode, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(godId, (int)languageCode);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodSkinsMethod, urlPath, cancellationToken);
        IEnumerable<GodSkin> result = await GetAsync<IEnumerable<GodSkin>>(url, cancellationToken);
        return _mapperService.MapAll<GodSkin, GodSkinDto>(result);
    }
}
