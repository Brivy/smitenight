using Smitenight.Application.Blazor.Business.Contracts.Facades.SmiteClient;
using Smitenight.Application.Blazor.Business.Contracts.Services.Cache;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Clients.TeamClient;
using Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;

namespace Smitenight.Application.Blazor.Business.Facades.SmiteClient
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
