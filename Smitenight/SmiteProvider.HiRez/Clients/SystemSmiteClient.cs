using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.SystemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Services;
using Smitenight.Utilities.Mapper.Common.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class SystemSmiteClient : SmiteClient, ISystemSmiteClient
    {
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapperService _mapperService;

        public SystemSmiteClient(HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapperService mapperService) : base(httpClient)
        {
            _smiteClientUrlService = smiteClientUrlService;
            _mapperService = mapperService;
        }

        public async Task<CreateSmiteSessionDto> CreateSmiteSessionAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.CreateSessionMethod, cancellationToken);
            var result = await GetAsync<CreateSmiteSession>(url, cancellationToken);
            return _mapperService.Map<CreateSmiteSession, CreateSmiteSessionDto>(result);
        }

        public Task TestSmiteSessionAsync(CancellationToken cancellationToken = default)
        {
            var url = _smiteClientUrlService.ConstructPingUrl();
            return PingAsync(url, cancellationToken);
        }

        public async Task<IEnumerable<DataUsedDto>> GetDataUsedAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.DataUsedMethod, cancellationToken);
            var result = await GetAsync<IEnumerable<DataUsed>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<DataUsed>, IEnumerable<DataUsedDto>>(result);
        }

        public async Task<IEnumerable<HirezServerStatusDto>> GetHirezServerStatusAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.HirezServerStatusMethod, cancellationToken);
            var result = await GetAsync<IEnumerable<HirezServerStatus>>(url, cancellationToken);
            return _mapperService.Map<IEnumerable<HirezServerStatus>, IEnumerable<HirezServerStatusDto>>(result);
        }

        public async Task<PatchInfoDto> GetPatchInfoAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PatchInfoMethod, cancellationToken);
            var result = await GetAsync<PatchInfo>(url, cancellationToken);
            return _mapperService.Map<PatchInfo, PatchInfoDto>(result);
        }
    }
}
