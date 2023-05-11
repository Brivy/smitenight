using AutoMapper;
using Smitenight.Domain.Models.Clients.SystemClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Models.SystemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class SystemSmiteClient : SmiteClient, ISystemSmiteClient
    {
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapper _mapper;

        public SystemSmiteClient(HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapper mapper) : base(httpClient)
        {
            _smiteClientUrlService = smiteClientUrlService;
            _mapper = mapper;
        }

        public async Task<CreateSmiteSessionDto> CreateSmiteSessionAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.CreateSessionMethod, cancellationToken);
            var result = await GetAsync<CreateSmiteSession>(url, cancellationToken);
            return _mapper.Map<CreateSmiteSessionDto>(result);
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
            return _mapper.Map<IEnumerable<DataUsedDto>>(result);
        }

        public async Task<IEnumerable<HirezServerStatusDto>> GetHirezServerStatusAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.HirezServerStatusMethod, cancellationToken);
            var result = await GetAsync<IEnumerable<HirezServerStatus>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<HirezServerStatusDto>>(result);
        }

        public async Task<PatchInfoDto> GetPatchInfoAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PatchInfoMethod, cancellationToken);
            var result = await GetAsync<PatchInfo>(url, cancellationToken);
            return _mapper.Map<PatchInfoDto>(result);
        }
    }
}
