using Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.SystemClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients;

public partial class SmiteClient
{
    public Task TestSmiteSessionAsync(CancellationToken cancellationToken = default)
    {
        string url = _smiteClientUrlService.ConstructPingUrl();
        return PingAsync(url, cancellationToken);
    }

    public async Task<IEnumerable<DataUsedDto>> GetDataUsedAsync(CancellationToken cancellationToken = default)
    {
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.DataUsedMethod, cancellationToken);
        IEnumerable<DataUsed> result = await GetAsync<IEnumerable<DataUsed>>(url, cancellationToken);
        return _mapperService.MapAll<DataUsed, DataUsedDto>(result);
    }

    public async Task<IEnumerable<HirezServerStatusDto>> GetHirezServerStatusAsync(CancellationToken cancellationToken = default)
    {
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.HirezServerStatusMethod, cancellationToken);
        IEnumerable<HirezServerStatus> result = await GetAsync<IEnumerable<HirezServerStatus>>(url, cancellationToken);
        return _mapperService.MapAll<HirezServerStatus, HirezServerStatusDto>(result);
    }

    public async Task<PatchInfoDto> GetPatchInfoAsync(CancellationToken cancellationToken = default)
    {
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PatchInfoMethod, cancellationToken);
        PatchInfo result = await GetAsync<PatchInfo>(url, cancellationToken);
        return _mapperService.Map<PatchInfo, PatchInfoDto>(result);
    }
}
