using AutoMapper;
using Smitenight.Domain.Models.Clients.OtherClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Models.OtherClient;
using Smitenight.Providers.SmiteProvider.HiRez.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class OtherSmiteSmiteClient : SmiteClient, IOtherSmiteClient
    {
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapper _mapper;

        public OtherSmiteSmiteClient(HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapper mapper) : base(httpClient)
        {
            _smiteClientUrlService = smiteClientUrlService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EsportProLeagueDto>> GetEsportProLeagueAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.EsportProLeagueMethod, cancellationToken);
            var result = await GetAsync<IEnumerable<EsportProLeague>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<EsportProLeagueDto>>(result);
        }

        public async Task<IEnumerable<MotdDto>> GetMotdAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MotdMethod, cancellationToken);
            var result = await GetAsync<IEnumerable<Motd>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<MotdDto>>(result);
        }
    }
}
