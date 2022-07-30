using SmitenightApp.Domain.Clients.SmiteClient.Requests.TeamRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.TeamResponses;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface ITeamClient
{
    Task<SmiteClientListResponse<TeamDetailsResponse>?> GetTeamDetailsAsync(
        TeamDetailsRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<TeamPlayersResponse>?> GetTeamPlayersAsync(
        TeamPlayersRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<SearchTeamsResponse>?> SearchTeamsAsync(
        SearchTeamsRequest request, CancellationToken cancellationToken);
}