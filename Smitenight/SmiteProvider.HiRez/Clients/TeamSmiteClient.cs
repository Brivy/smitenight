using AutoMapper;
using Smitenight.Domain.Models.Clients.TeamClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Responses.TeamClient;
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

        public async Task<IEnumerable<TeamDetails>> GetTeamDetailsAsync(int clanId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(clanId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.TeamDetailsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<TeamDetailsResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<TeamDetails>>(result);
        }

        public async Task<IEnumerable<TeamPlayer>> GetTeamPlayersAsync(int clanId, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(clanId);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.TeamPlayersMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<TeamPlayersResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<TeamPlayer>>(result);
        }

        public async Task<IEnumerable<SearchTeams>> SearchTeamsAsync(string teamName, CancellationToken cancellationToken = default)
        {
            var urlPath = _smiteClientUrlService.ConstructUrlPath(teamName);
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.SearchTeamsMethod, urlPath, cancellationToken);
            var result = await GetAsync<IEnumerable<SearchTeamsResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<SearchTeams>>(result);
        }
    }
}
