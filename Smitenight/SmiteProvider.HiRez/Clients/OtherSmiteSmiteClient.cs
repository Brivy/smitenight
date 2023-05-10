using AutoMapper;
using Smitenight.Domain.Models.Clients.OtherClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Responses.OtherClient;
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

        public async Task<IEnumerable<EsportProLeague>> GetEsportProLeagueAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.EsportProLeagueMethod, cancellationToken);
            var result = await GetAsync<IEnumerable<EsportProLeagueResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<EsportProLeague>>(result);
        }

        public async Task<IEnumerable<Motd>> GetMotdAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MotdMethod, cancellationToken);
            var result = await GetAsync<IEnumerable<MotdResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<Motd>>(result);
        }
    }
}
