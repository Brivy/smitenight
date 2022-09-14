using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Application.System;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.PlayerResponses;
using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.PlayerResponses;
using SmitenightApp.Infrastructure.SmiteClient.Models;
using SmitenightApp.Infrastructure.SmiteClient.Secrets;
using SmitenightApp.Infrastructure.SmiteClient.Settings;

namespace SmitenightApp.Infrastructure.SmiteClient.Clients
{
    public class PlayerClient : SmiteClient, IPlayerInfoClient
    {
        public PlayerClient(HttpClient httpClient,
            ISmiteSessionService smiteSessionService,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteSessionService, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<FriendsResponse>?> GetFriendsAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(playerId);
            var request = new SmiteClientRequest(MethodNameConstants.FriendsMethod, urlPath);
            var result = await GetListAsync<FriendsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<FriendsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<GodRanksResponse>?> GetGodRanksAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(playerId);
            var request = new SmiteClientRequest(MethodNameConstants.GodRanksMethod, urlPath);
            var result = await GetListAsync<GodRanksResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<GodRanksResponse>>(result);
        }

        public async Task<SmiteClientResponse<PlayerAchievementsResponse>?> GetPlayerAchievementsAsync(int playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(playerId);
            var request = new SmiteClientRequest(MethodNameConstants.PlayerAchievementsMethod, urlPath);
            var result = await GetAsync<PlayerAchievementsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientResponse<PlayerAchievementsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerStatusResponse>?> GetPlayerStatusAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(playerId);
            var request = new SmiteClientRequest(MethodNameConstants.PlayerStatusMethod, urlPath);
            var result = await GetListAsync<PlayerStatusResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerStatusResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MatchHistoryResponse>?> GetMatchHistoryAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(playerId);
            var request = new SmiteClientRequest(MethodNameConstants.MatchHistoryMethod, urlPath);
            var result = await GetListAsync<MatchHistoryResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MatchHistoryResponse>>(result);
        }

        public async Task<SmiteClientListResponse<QueueStatsResponse>?> GetQueueStatsAsync(string playerId, GameModeQueueIdEnum gameModeQueueId, 
            CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(playerId, (int) gameModeQueueId);
            var request = new SmiteClientRequest(MethodNameConstants.QueueStatsMethod, urlPath);
            var result = await GetListAsync<QueueStatsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<QueueStatsResponse>>(result);
        }

        public async Task<SmiteClientListResponse<SearchPlayersResponse>?> SearchPlayersAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath(playerId);
            var request = new SmiteClientRequest(MethodNameConstants.SearchPlayersMethod, urlPath);
            var result = await GetListAsync<SearchPlayersResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<SearchPlayersResponse>>(result);
        }
    }
}
