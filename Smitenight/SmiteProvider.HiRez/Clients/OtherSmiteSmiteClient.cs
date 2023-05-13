using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.Contracts.Models.OtherClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.OtherClient;
using Smitenight.Providers.SmiteProvider.HiRez.Services;
using Smitenight.Utilities.Mapper.Common.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class OtherSmiteSmiteClient : SmiteClient, IOtherSmiteClient
    {
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapperService _mapperService;

        public OtherSmiteSmiteClient(HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapperService mapperService) : base(httpClient)
        {
            _smiteClientUrlService = smiteClientUrlService;
            _mapperService = mapperService;
        }

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
