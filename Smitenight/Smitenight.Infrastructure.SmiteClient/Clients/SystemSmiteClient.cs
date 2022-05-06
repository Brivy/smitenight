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
            PingHirezRequest pingHirezRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(pingHirezRequest);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetAsync(url, cancellationToken);
            return Mapper.Map<SmiteClientResponse>(result);
        }

        public async Task<SmiteClientResponse<CreateSmiteSessionResponse>?> CreateSmiteSessionAsync(
            CreateSmiteSessionRequest createSmiteSessionRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(createSmiteSessionRequest);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetAsync<CreateSmiteSessionResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientResponse<CreateSmiteSessionResponse>>(result);
        }

        public async Task<SmiteClientResponse?> TestSmiteSessionAsync(
            TestSmiteSessionRequest testSmiteSessionRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(testSmiteSessionRequest);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetAsync(url, cancellationToken);
            return Mapper.Map<SmiteClientResponse>(result);
        }

        public async Task<SmiteClientListResponse<DataUsedResponse>?> GetDataUsedAsync(
            DataUsedRequest dataUsedRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(dataUsedRequest);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<DataUsedResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<DataUsedResponse>>(result);
        }

        public async Task<SmiteClientListResponse<HirezServerStatusResponse>?> GetHirezServerStatusAsync(
            HirezServerStatusRequest hirezServerStatusRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(hirezServerStatusRequest);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetListAsync<HirezServerStatusResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<HirezServerStatusResponse>>(result);
        }

        public async Task<SmiteClientResponse<PatchInfoResponse>?> GetPatchInfoAsync(
            PatchInfoRequest patchInfoRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(patchInfoRequest);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetAsync<PatchInfoResponseDto>(url, cancellationToken);
            return Mapper.Map<SmiteClientResponse<PatchInfoResponse>>(result);
        }
    }
}
