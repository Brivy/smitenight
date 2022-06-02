using Smitenight.Domain.Clients.SmiteClient.Requests.TeamRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.TeamResponses;

namespace Smitenight.Abstractions.Infrastructure.SmiteClient;

public interface ITeamClient
{
    Task<SmiteClientListResponse<TeamDetailsResponse>?> GetTeamDetailsAsync(
        TeamDetailsRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<TeamPlayersResponse>?> GetTeamPlayersAsync(
        TeamPlayersRequest request, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<SearchTeamsResponse>?> SearchTeamsAsync(
        SearchTeamsRequest request, CancellationToken cancellationToken);
}