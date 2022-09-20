using SmitenightApp.Abstractions.Application.Facades.SmiteClient;
using SmitenightApp.Abstractions.Application.Services.Cache;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Clients.TeamClient;

namespace SmitenightApp.Application.Facades.SmiteClient
{
    /// <summary>
    /// Simplified version without sessionId of <see cref="ITeamSmiteClient"/>
    /// </summary>
    public class TeamSmiteClientFacade : ITeamSmiteClientFacade
    {
        private readonly ITeamSmiteClient _teamSmiteClient;
        private readonly ISmiteSessionCacheService _smiteSessionCacheService;

        public TeamSmiteClientFacade(
            ITeamSmiteClient teamSmiteClient,
            ISmiteSessionCacheService smiteSessionCacheService)
        {
            _teamSmiteClient = teamSmiteClient;
            _smiteSessionCacheService = smiteSessionCacheService;
        }

        public async Task<SmiteClientListResponse<TeamDetailsResponse>?> GetTeamDetailsAsync(int clanId, CancellationToken cancellationToken = default) =>
            await _teamSmiteClient.GetTeamDetailsAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), clanId, cancellationToken);

        public async Task<SmiteClientListResponse<TeamPlayersResponse>?> GetTeamPlayersAsync(int clanId, CancellationToken cancellationToken = default) =>
            await _teamSmiteClient.GetTeamPlayersAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), clanId, cancellationToken);

        public async Task<SmiteClientListResponse<SearchTeamsResponse>?> SearchTeamsAsync(string teamName, CancellationToken cancellationToken = default) =>
            await _teamSmiteClient.SearchTeamsAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), teamName, cancellationToken);
    }
}
