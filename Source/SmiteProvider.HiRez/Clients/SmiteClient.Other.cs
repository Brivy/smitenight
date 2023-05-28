using Smitenight.Providers.SmiteProvider.Contracts.Models.OtherClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.OtherClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public partial class SmiteClient
    {
        public async Task<IEnumerable<EsportProLeagueDto>> GetEsportProLeagueAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.EsportProLeagueMethod, cancellationToken);
            var result = await GetAsync<IEnumerable<EsportProLeague>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<EsportProLeague>, IEnumerable<EsportProLeagueDto>>(result);
        }

        public async Task<IEnumerable<MotdDto>> GetMotdAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MotdMethod, cancellationToken);
            var result = await GetAsync<IEnumerable<Motd>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<Motd>, IEnumerable<MotdDto>>(result);
        }
    }
}
