using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Clients.TeamClient;

namespace SmitenightApp.Abstractions.Application.Facades.SmiteClient;

public interface ITeamSmiteClientFacade
{
    Task<SmiteClientListResponse<TeamDetailsResponse>?> GetTeamDetailsAsync(int clanId, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<TeamPlayersResponse>?> GetTeamPlayersAsync(int clanId, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<SearchTeamsResponse>?> SearchTeamsAsync(string teamName, CancellationToken cancellationToken = default);
}