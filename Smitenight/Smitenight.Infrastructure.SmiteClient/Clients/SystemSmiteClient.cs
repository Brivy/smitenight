using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.SystemResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts.SystemResponses;
using Smitenight.Infrastructure.SmiteClient.Settings;

namespace Smitenight.Infrastructure.SmiteClient.Clients
{
    public class SystemSmiteClient : SmiteClient, ISystemSmiteClient
    {
        public SystemSmiteClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IMapper mapper) : base(httpClient, smiteClientSettings, mapper)
        {
        }

        public async Task<SmiteClientResponse?> PingHirezAsync(
            PingHirezRequest request, CancellationToken cancellationToken)
        {
            var result = await GetAsync(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientResponse>(result);
        }

        public async Task<SmiteClientResponse<CreateSmiteSessionResponse>?> CreateSmiteSessionAsync(
            CreateSmiteSessionRequest request, CancellationToken cancellationToken)
        {
            var result = await GetAsync<CreateSmiteSessionResponseDto>(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientResponse<CreateSmiteSessionResponse>>(result);
        }

        public async Task<SmiteClientResponse?> TestSmiteSessionAsync(
            TestSmiteSessionRequest request, CancellationToken cancellationToken)
        {
            var result = await GetAsync(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientResponse>(result);
        }

        public async Task<SmiteClientListResponse<DataUsedResponse>?> GetDataUsedAsync(
            DataUsedRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<DataUsedResponseDto>(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientListResponse<DataUsedResponse>>(result);
        }

        public async Task<SmiteClientListResponse<HirezServerStatusResponse>?> GetHirezServerStatusAsync(
            HirezServerStatusRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<HirezServerStatusResponseDto>(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientListResponse<HirezServerStatusResponse>>(result);
        }

        public async Task<SmiteClientResponse<PatchInfoResponse>?> GetPatchInfoAsync(
            PatchInfoRequest request, CancellationToken cancellationToken)
        {
            var result = await GetAsync<PatchInfoResponseDto>(request.GetUrlPath(), cancellationToken);
            return Mapper.Map<SmiteClientResponse<PatchInfoResponse>>(result);
        }
    }
}
