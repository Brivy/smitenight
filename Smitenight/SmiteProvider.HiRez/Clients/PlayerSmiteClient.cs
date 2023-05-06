using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Domain.Models.Clients.PlayerClient;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;
using Smitenight.Providers.SmiteProvider.HiRez.Contracts.PlayerResponses;
using Smitenight.Providers.SmiteProvider.HiRez.Models;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Providers.SmiteProvider.HiRez.Settings;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class PlayerSmiteClient : SmiteClient, IPlayerSmiteClient
    {
        public PlayerSmiteClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<FriendsResponse>?> GetFriendsAsync(
            string sessionId, string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(playerId);
            var request = new SmiteClientRequest(MethodNameConstants.FriendsMethod, sessionId, urlPath);
            var result = await GetListAsync<FriendsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<FriendsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodRanksResponse>?> GetGodRanksAsync(
            string sessionId, string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(playerId);
            var request = new SmiteClientRequest(MethodNameConstants.GodRanksMethod, sessionId, urlPath);
            var result = await GetListAsync<GodRanksResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodRanksResponse>>(result);
        }

        public async Task<SmiteClientResponse<PlayerAchievementsResponse>?> GetPlayerAchievementsAsync(
            string sessionId, int playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(playerId);
            var request = new SmiteClientRequest(MethodNameConstants.PlayerAchievementsMethod, sessionId, urlPath);
            var result = await GetAsync<PlayerAchievementsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientResponse<PlayerAchievementsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerStatusResponse>?> GetPlayerStatusAsync(
            string sessionId, string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(playerId);
            var request = new SmiteClientRequest(MethodNameConstants.PlayerStatusMethod, sessionId, urlPath);
            var result = await GetListAsync<PlayerStatusResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerStatusResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchHistoryResponse>?> GetMatchHistoryAsync(
            string sessionId, string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(playerId);
            var request = new SmiteClientRequest(MethodNameConstants.MatchHistoryMethod, sessionId, urlPath);
            var result = await GetListAsync<MatchHistoryResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchHistoryResponse>>(result);
        }

        public async Task<SmiteClientListResponse<QueueStatsResponse>?> GetQueueStatsAsync(
            string sessionId, string playerId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(playerId, (int)gameModeQueueId);
            var request = new SmiteClientRequest(MethodNameConstants.QueueStatsMethod, sessionId, urlPath);
            var result = await GetListAsync<QueueStatsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<QueueStatsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<SearchPlayersResponse>?> SearchPlayersAsync(
            string sessionId, string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(playerId);
            var request = new SmiteClientRequest(MethodNameConstants.SearchPlayersMethod, sessionId, urlPath);
            var result = await GetListAsync<SearchPlayersResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<SearchPlayersResponse>>(result);
        }
    }
}
