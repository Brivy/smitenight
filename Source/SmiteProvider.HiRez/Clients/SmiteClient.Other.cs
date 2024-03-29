﻿using Smitenight.Providers.SmiteProvider.Contracts.Models.OtherClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.OtherClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients;

public partial class SmiteClient
{
    public async Task<IEnumerable<EsportProLeagueDto>> GetEsportProLeagueAsync(CancellationToken cancellationToken = default)
    {
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.EsportProLeagueMethod, cancellationToken);
        IEnumerable<EsportProLeague> result = await GetAsync<IEnumerable<EsportProLeague>>(url, cancellationToken);
        return _mapperService.MapAll<EsportProLeague, EsportProLeagueDto>(result);
    }

    public async Task<IEnumerable<MotdDto>> GetMotdAsync(CancellationToken cancellationToken = default)
    {
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MotdMethod, cancellationToken);
        IEnumerable<Motd> result = await GetAsync<IEnumerable<Motd>>(url, cancellationToken);
        return _mapperService.MapAll<Motd, MotdDto>(result);
    }
}
