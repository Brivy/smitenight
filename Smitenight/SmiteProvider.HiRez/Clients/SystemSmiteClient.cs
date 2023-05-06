using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Clients.SystemClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;
using Smitenight.Providers.SmiteProvider.HiRez.Contracts.SystemResponses;
using Smitenight.Providers.SmiteProvider.HiRez.Models;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Providers.SmiteProvider.HiRez.Settings;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class SystemSmiteClient : SmiteClient, ISystemSmiteClient
    {
        public SystemSmiteClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientResponse<CreateSmiteSessionResponse>?> CreateSmiteSessionAsync(
            CancellationToken cancellationToken = default)
        {
            var request = new SmiteClientRequest(MethodNameConstants.CreateSessionMethod);
            var result = await GetAsync<CreateSmiteSessionResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientResponse<CreateSmiteSessionResponse>>(result);
        }

        public async Task<SmiteClientResponse?> TestSmiteSessionAsync(
            string sessionId, CancellationToken cancellationToken = default)
        {
            var request = new SmiteClientRequest(MethodNameConstants.TestSessionMethod, sessionId);
            var result = await GetAsync(request, cancellationToken);
            return Mapper.Map<SmiteClientResponse>(result);
        }

        public async Task<SmiteClientListResponse<DataUsedResponse>?> GetDataUsedAsync(
            string sessionId, CancellationToken cancellationToken = default)
        {
            var request = new SmiteClientRequest(MethodNameConstants.DataUsedMethod, sessionId);
            var result = await GetListAsync<DataUsedResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<DataUsedResponse>>(result);
        }

        public async Task<SmiteClientListResponse<HirezServerStatusResponse>?> GetHirezServerStatusAsync(
            string sessionId, CancellationToken cancellationToken = default)
        {
            var request = new SmiteClientRequest(MethodNameConstants.HirezServerStatusMethod, sessionId);
            var result = await GetListAsync<HirezServerStatusResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<HirezServerStatusResponse>>(result);
        }

        public async Task<SmiteClientResponse<PatchInfoResponse>?> GetPatchInfoAsync(
            string sessionId, CancellationToken cancellationToken = default)
        {
            var request = new SmiteClientRequest(MethodNameConstants.PatchInfoMethod, sessionId);
            var result = await GetAsync<PatchInfoResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientResponse<PatchInfoResponse>>(result);
        }
    }
}
