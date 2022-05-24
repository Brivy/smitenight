using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.PlayerInfoRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.PlayerInfoResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.PlayerInfoResponses;
using Smitenight.Infrastructure.SmiteClient.Settings;

namespace Smitenight.Infrastructure.SmiteClient.Clients
{
    public class PlayerInfoClient : SmiteClient, IPlayerInfoClient
    {
        public PlayerInfoClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IMapper mapper) : base(httpClient, smiteClientSettings, mapper)
        {
        }

        public async Task<SmiteClientListResponse<FriendsResponse>?> GetFriendsAsync(
            FriendsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<FriendsResponseDto>(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientListResponse<FriendsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodRanksResponse>?> GetGodRanksAsync(
            GodRanksRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<GodRanksResponseDto>(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodRanksResponse>>(result);
        }

        public async Task<SmiteClientResponse<PlayerAchievementsResponse>?> GetPlayerAchievementsAsync(
            PlayerAchievementsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetAsync<PlayerAchievementsResponseDto>(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientResponse<PlayerAchievementsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerStatusResponse>?> GetPlayerStatusAsync(
            PlayerStatusRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<PlayerStatusResponseDto>(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerStatusResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchHistoryResponse>?> GetMatchHistoryAsync(
            MatchHistoryRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<MatchHistoryResponseDto>(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchHistoryResponse>>(result);
        }

        public async Task<SmiteClientListResponse<QueueStatsResponse>?> GetQueueStatsAsync(
            QueueStatsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<QueueStatsResponseDto>(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientListResponse<QueueStatsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<SearchPlayersResponse>?> SearchPlayersAsync(
            SearchPlayersRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<SearchPlayersResponseDto>(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientListResponse<SearchPlayersResponse>>(result);
        }
    }
}
