using Smitenight.Application.Blazor.Business.Contracts.Facades.SmiteClient;
using Smitenight.Application.Blazor.Business.Contracts.Services.Cache;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Clients.SystemClient;
using Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;

namespace Smitenight.Application.Blazor.Business.Facades.SmiteClient
{
    /// <summary>
    /// Simplified version without sessionId of <see cref="ISystemSmiteClient"/>
    /// </summary>
    public class SystemSmiteClientFacade : ISystemSmiteClientFacade
    {
        private readonly ISystemSmiteClient _systemSmiteClient;
        private readonly ISmiteSessionCacheService _smiteSessionCacheService;

        public SystemSmiteClientFacade(
            ISystemSmiteClient systemSmiteClient,
            ISmiteSessionCacheService smiteSessionCacheService)
        {
            _systemSmiteClient = systemSmiteClient;
            _smiteSessionCacheService = smiteSessionCacheService;
        }

        public async Task<SmiteClientResponse?> TestSmiteSessionAsync(CancellationToken cancellationToken = default) =>
            await _systemSmiteClient.TestSmiteSessionAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), cancellationToken);

        public async Task<SmiteClientListResponse<DataUsedResponse>?> GetDataUsedAsync(CancellationToken cancellationToken = default) =>
            await _systemSmiteClient.GetDataUsedAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), cancellationToken);

        public async Task<SmiteClientListResponse<HirezServerStatusResponse>?> GetHirezServerStatusAsync(CancellationToken cancellationToken = default) =>
            await _systemSmiteClient.GetHirezServerStatusAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), cancellationToken);

        public async Task<SmiteClientResponse<PatchInfoResponse>?> GetPatchInfoAsync(CancellationToken cancellationToken = default) =>
            await _systemSmiteClient.GetPatchInfoAsync(await _smiteSessionCacheService.GetSessionIdAsync(cancellationToken), cancellationToken);
    }
}
