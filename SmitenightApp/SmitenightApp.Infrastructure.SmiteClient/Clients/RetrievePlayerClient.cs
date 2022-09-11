using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Abstractions.Infrastructure.System;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.RetrievePlayerResponses;
using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.RetrievePlayerResponses;
using SmitenightApp.Infrastructure.SmiteClient.Models;
using SmitenightApp.Infrastructure.SmiteClient.Secrets;
using SmitenightApp.Infrastructure.SmiteClient.Settings;

namespace SmitenightApp.Infrastructure.SmiteClient.Clients
{
    public class RetrievePlayerClient : SmiteClient, IRetrievePlayerClient
    {
        public RetrievePlayerClient(HttpClient httpClient,
            ISmiteSessionService smiteSessionService,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteSessionService, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerAsync(
            string sessionId, string playerId, PortalTypeEnum portalType, CancellationToken cancellationToken)
        {
            var urlPath = ConstructUrlPath(playerId, (int) portalType);
            var request = new SmiteClientRequest(MethodNameConstants.PlayerMethod, sessionId, urlPath);
            var result = await GetListAsync<PlayerResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerWithoutPortalAsync(
            string sessionId, string playerName, CancellationToken cancellationToken)
        {
            var urlPath = ConstructUrlPath(playerName);
            var request = new SmiteClientRequest(MethodNameConstants.PlayerMethod, sessionId, urlPath);
            var result = await GetListAsync<PlayerResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPlayerNameAsync(
            string sessionId, string playerName, CancellationToken cancellationToken)
        {
            var urlPath = ConstructUrlPath(playerName);
            var request = new SmiteClientRequest(MethodNameConstants.PlayerIdByNameMethod, sessionId, urlPath);
            var result = await GetListAsync<PlayerIdResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerIdResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPortalUserAsync(
            string sessionId, PortalTypeEnum portalType, string portalUserId, CancellationToken cancellationToken)
        {
            var urlPath = ConstructUrlPath((int) portalType, portalUserId);
            var request = new SmiteClientRequest(MethodNameConstants.PlayerIdByPortalUserIdMethod, sessionId, urlPath);
            var result = await GetListAsync<PlayerIdResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerIdResponse>>(result);
        }

        public async Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByGamerTagAsync(
            string sessionId, PortalTypeEnum portalType, string gamerTag, CancellationToken cancellationToken)
        {
            var urlPath = ConstructUrlPath((int) portalType, gamerTag);
            var request = new SmiteClientRequest(MethodNameConstants.PlayerIdByGamerTagMethod, sessionId, urlPath);
            var result = await GetListAsync<PlayerIdResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<PlayerIdResponse>>(result);
        }
    }
}
