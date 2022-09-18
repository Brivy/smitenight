using SmitenightApp.Abstractions.Application.Facades.SmiteClient;
using SmitenightApp.Abstractions.Application.Services.Cache;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.OtherClient;
using SmitenightApp.Domain.Clients.SmiteClient;

namespace SmitenightApp.Application.Facades.SmiteClient
{
    /// <summary>
    /// Simplified version without sessionId of <see cref="IOtherSmiteClient"/>
    /// </summary>
    public class OtherSmiteClientFacade : IOtherSmiteClientFacade
    {
        private readonly IOtherSmiteClient _otherSmiteClient;
        private readonly ISmiteSessionCacheService _smiteSessionCacheService;

        public OtherSmiteClientFacade(IOtherSmiteClient otherSmiteClient,
            ISmiteSessionCacheService smiteSessionCacheService)
        {
            _otherSmiteClient = otherSmiteClient;
            _smiteSessionCacheService = smiteSessionCacheService;
        }

        public async Task<SmiteClientListResponse<EsportProLeagueResponse>?> GetEsportProLeagueAsync(CancellationToken cancellationToken = default) =>
            await _otherSmiteClient.GetEsportProLeagueAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), cancellationToken);

        public async Task<SmiteClientListResponse<MotdResponse>?> GetMotdAsync(CancellationToken cancellationToken = default) =>
            await _otherSmiteClient.GetMotdAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), cancellationToken);
    }
}
