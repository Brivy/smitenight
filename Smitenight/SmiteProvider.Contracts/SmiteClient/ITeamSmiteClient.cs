using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Clients.TeamClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;

public interface ITeamSmiteClient
{
    Task<SmiteClientListResponse<TeamDetailsResponse>?> GetTeamDetailsAsync(
        string sessionId, int clanId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<TeamPlayersResponse>?> GetTeamPlayersAsync(
        string sessionId, int clanId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<SearchTeamsResponse>?> SearchTeamsAsync(
        string sessionId, string teamName, CancellationToken cancellationToken = default);
}