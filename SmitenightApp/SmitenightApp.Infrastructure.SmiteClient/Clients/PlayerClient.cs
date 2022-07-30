using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.SmiteClient.Requests.PlayerRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.PlayerResponses;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.PlayerResponses;
using SmitenightApp.Infrastructure.SmiteClient.Secrets;
using SmitenightApp.Infrastructure.SmiteClient.Settings;

namespace SmitenightApp.Infrastructure.SmiteClient.Clients
{
    public class PlayerClient : SmiteClient, IPlayerInfoClient
    {
        public PlayerClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<FriendsResponse>?> GetFriendsAsync(
            FriendsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<FriendsRequest, FriendsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<FriendsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodRanksResponse>?> GetGodRanksAsync(
            GodRanksRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<GodRanksRequest, GodRanksResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodRanksResponse>>(result);
        }

        public async Task<SmiteClientResponse<PlayerAchievementsResponse>?> GetPlayerAchievementsAsync(
            PlayerAchievementsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetAsync<PlayerAchievementsRequest, PlayerAchievementsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientResponse<PlayerAchievementsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerStatusResponse>?> GetPlayerStatusAsync(
            PlayerStatusRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<PlayerStatusRequest, PlayerStatusResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerStatusResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchHistoryResponse>?> GetMatchHistoryAsync(
            MatchHistoryRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<MatchHistoryRequest, MatchHistoryResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchHistoryResponse>>(result);
        }

        public async Task<SmiteClientListResponse<QueueStatsResponse>?> GetQueueStatsAsync(
            QueueStatsRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<QueueStatsRequest, QueueStatsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<QueueStatsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<SearchPlayersResponse>?> SearchPlayersAsync(
            SearchPlayersRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<SearchPlayersRequest, SearchPlayersResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<SearchPlayersResponse>>(result);
        }
    }
}
