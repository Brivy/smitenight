using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Clients.TeamClient;

namespace Smitenight.Application.Blazor.Business.Contracts.Facades.SmiteClient;

public interface ITeamSmiteClientFacade
{
    Task<SmiteClientListResponse<TeamDetailsResponse>?> GetTeamDetailsAsync(int clanId, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<TeamPlayersResponse>?> GetTeamPlayersAsync(int clanId, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<SearchTeamsResponse>?> SearchTeamsAsync(string teamName, CancellationToken cancellationToken = default);
}