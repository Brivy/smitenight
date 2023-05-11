using AutoMapper;
using Smitenight.Domain.Models.Clients.TeamClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Models.TeamClient;
using Smitenight.Providers.SmiteProvider.HiRez.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class TeamSmiteClient : SmiteClient, ITeamSmiteClient
    {
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapper _mapper;

        public TeamSmiteClient(HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapper mapper) : base(httpClient)
        {
            _smiteClientUrlService = smiteClientUrlService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamDetailsDto>> GetTeamDetailsAsync(int clanId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(clanId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.TeamDetailsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<TeamDetails>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<TeamDetailsDto>>(result);
        }

        public async Task<IEnumerable<TeamPlayerDto>> GetTeamPlayersAsync(int clanId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(clanId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.TeamPlayersMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<TeamPlayers>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<TeamPlayerDto>>(result);
        }

        public async Task<IEnumerable<SearchTeamsDto>> SearchTeamsAsync(string teamName, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(teamName);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.SearchTeamsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<SearchTeams>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<SearchTeamsDto>>(result);
        }
    }
}
