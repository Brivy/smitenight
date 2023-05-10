using AutoMapper;
using Smitenight.Domain.Models.Clients.SystemClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.HiRez.Responses.SystemClient;
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

        public async Task<CreateSmiteSession> CreateSmiteSessionAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.CreateSessionMethod, cancellationToken);
            var result = await GetAsync<CreateSmiteSessionResponseDto>(url, cancellationToken);
            return _mapper.Map<CreateSmiteSession>(result);
        }

        public Task TestSmiteSessionAsync(CancellationToken cancellationToken = default)
        {
            var url = _smiteClientUrlService.ConstructPingUrl();
            return PingAsync(url, cancellationToken);
        }

        public async Task<IEnumerable<DataUsed>> GetDataUsedAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.DataUsedMethod, cancellationToken);
            var result = await GetAsync<IEnumerable<DataUsedResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<DataUsed>>(result);
        }

        public async Task<IEnumerable<HirezServerStatus>> GetHirezServerStatusAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.HirezServerStatusMethod, cancellationToken);
            var result = await GetAsync<IEnumerable<HirezServerStatusResponseDto>>(url, cancellationToken);
            return _mapper.Map<IEnumerable<HirezServerStatus>>(result);
        }

        public async Task<PatchInfo> GetPatchInfoAsync(CancellationToken cancellationToken = default)
        {
            var url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PatchInfoMethod, cancellationToken);
            var result = await GetAsync<PatchInfoResponseDto>(url, cancellationToken);
            return _mapper.Map<PatchInfo>(result);
        }
    }
}
