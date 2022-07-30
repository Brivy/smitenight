using SmitenightApp.Domain.Clients.SmiteClient.Requests.LeagueRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.LeagueResponses;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient
{
    public interface ILeagueClient
    {
        Task<SmiteClientListResponse<LeagueLeaderboardResponse>?> GetLeagueLeaderboardAsync(
            LeagueLeaderboardRequest request, CancellationToken cancellationToken);

        Task<SmiteClientListResponse<LeagueSeasonsResponse>?> GetLeagueSeasonsAsync(
            LeagueSeasonsRequest request, CancellationToken cancellationToken);
    }
}