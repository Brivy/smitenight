using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.TeamResponses;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface ITeamClient
{
    Task<SmiteClientListResponse<TeamDetailsResponse>?> GetTeamDetailsAsync(
        string sessionId, int clanId, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<TeamPlayersResponse>?> GetTeamPlayersAsync(
        string sessionId, int clanId, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<SearchTeamsResponse>?> SearchTeamsAsync(
        string sessionId, string teamName, CancellationToken cancellationToken);
}