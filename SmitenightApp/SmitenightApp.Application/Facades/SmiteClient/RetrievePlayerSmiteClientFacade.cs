using SmitenightApp.Abstractions.Application.Facades.SmiteClient;
using SmitenightApp.Abstractions.Application.Services.Cache;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.RetrievePlayerClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Application.Facades.SmiteClient
{
    /// <summary>
    /// Simplified version without sessionId of <see cref="IRetrievePlayerSmiteClient"/>
    /// </summary>
    public class RetrievePlayerSmiteClientFacade : IRetrievePlayerSmiteClientFacade
    {
        private readonly IRetrievePlayerSmiteClient _retrievePlayerSmiteClient;
        private readonly ISmiteSessionCacheService _smiteSessionCacheService;

        public RetrievePlayerSmiteClientFacade(
            IRetrievePlayerSmiteClient retrievePlayerSmiteClient,
            ISmiteSessionCacheService smiteSessionCacheService)
        {
            _retrievePlayerSmiteClient = retrievePlayerSmiteClient;
            _smiteSessionCacheService = smiteSessionCacheService;
        }

        public async Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerAsync(string playerId, PortalTypeEnum portalType, CancellationToken cancellationToken = default) =>
            await _retrievePlayerSmiteClient.GetPlayerAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), playerId, portalType, cancellationToken);

        public async Task<SmiteClientListResponse<PlayerResponse>?> GetPlayerWithoutPortalAsync(string playerName, CancellationToken cancellationToken = default) =>
            await _retrievePlayerSmiteClient.GetPlayerWithoutPortalAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), playerName, cancellationToken);

        public async Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPlayerNameAsync(string playerName, CancellationToken cancellationToken = default) =>
            await _retrievePlayerSmiteClient.GetPlayerIdByPlayerNameAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), playerName, cancellationToken);

        public async Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByPortalUserAsync(PortalTypeEnum portalType, string portalUserId, CancellationToken cancellationToken = default) =>
            await _retrievePlayerSmiteClient.GetPlayerIdByPortalUserAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), portalType, portalUserId, cancellationToken);

        public async Task<SmiteClientListResponse<PlayerIdResponse>?> GetPlayerIdByGamerTagAsync(PortalTypeEnum portalType, string gamerTag, CancellationToken cancellationToken = default) =>
            await _retrievePlayerSmiteClient.GetPlayerIdByGamerTagAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), portalType, gamerTag, cancellationToken);
    }
}
