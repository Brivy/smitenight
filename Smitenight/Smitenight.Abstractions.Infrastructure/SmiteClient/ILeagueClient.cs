using Smitenight.Domain.Clients.SmiteClient.Requests.LeagueRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.LeagueResponses;

namespace Smitenight.Abstractions.Infrastructure.SmiteClient
{
    public interface ILeagueClient
    {
        Task<SmiteClientListResponse<LeagueLeaderboardResponse>?> GetLeagueLeaderboardAsync(
            LeagueLeaderboardRequest request, CancellationToken cancellationToken);

        Task<SmiteClientListResponse<LeagueSeasonsResponse>?> GetLeagueSeasonsAsync(
            LeagueSeasonsRequest request, CancellationToken cancellationToken);
    }
}