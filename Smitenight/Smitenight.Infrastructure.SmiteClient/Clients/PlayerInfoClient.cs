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
            FriendsRequest friendsRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(friendsRequest, friendsRequest.PlayerId);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<FriendsResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<FriendsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodRanksResponse>?> GetGodRanksAsync(
            GodRanksRequest godRanksRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(godRanksRequest, godRanksRequest.PlayerId);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<GodRanksResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodRanksResponse>>(result);
        }

        public async Task<SmiteClientResponse<PlayerAchievementsResponse>?> GetPlayerAchievementsAsync(
            PlayerAchievementsRequest playerAchievementsRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(playerAchievementsRequest, playerAchievementsRequest.PlayerId);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetAsync<PlayerAchievementsResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientResponse<PlayerAchievementsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerStatusResponse>?> GetPlayerStatusAsync(
            PlayerStatusRequest playerStatusRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(playerStatusRequest, playerStatusRequest.PlayerId);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<PlayerStatusResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerStatusResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchHistoryResponse>?> GetMatchHistoryAsync(
            MatchHistoryRequest matchHistoryRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(matchHistoryRequest, matchHistoryRequest.PlayerId);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<MatchHistoryResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchHistoryResponse>>(result);
        }

        public async Task<SmiteClientListResponse<QueueStatsResponse>?> GetQueueStatsAsync(
            QueueStatsRequest queueStatsRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(queueStatsRequest, queueStatsRequest.PlayerId, (int)queueStatsRequest.GameModeQueueId);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<QueueStatsResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<QueueStatsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<SearchPlayersResponse>?> SearchPlayersAsync(
            SearchPlayersRequest searchPlayersRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(searchPlayersRequest, searchPlayersRequest.PlayerId);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<SearchPlayersResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<SearchPlayersResponse>>(result);
        }
    }
}
