using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Clients.TeamClient;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface ITeamSmiteClient
{
    Task<SmiteClientListResponse<TeamDetailsResponse>?> GetTeamDetailsAsync(
        string sessionId, int clanId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<TeamPlayersResponse>?> GetTeamPlayersAsync(
        string sessionId, int clanId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<SearchTeamsResponse>?> SearchTeamsAsync(
        string sessionId, string teamName, CancellationToken cancellationToken = default);
}