using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.TeamResponses;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface ITeamClient
{
    Task<SmiteClientListResponse<TeamDetailsResponse>?> GetTeamDetailsAsync(
        int clanId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<TeamPlayersResponse>?> GetTeamPlayersAsync(
        int clanId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<SearchTeamsResponse>?> SearchTeamsAsync(
        string teamName, CancellationToken cancellationToken = default);
}