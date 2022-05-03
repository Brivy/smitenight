using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Domain.Clients.SmiteClient.Responses.SystemResponses;
using Smitenight.Infrastructure.SmiteClient.Contracts;
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

        public async Task<SmiteClientResponseModel?> PingHirezAsync(
            PingHirezRequest pingHirezRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(pingHirezRequest);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetAsync(url, cancellationToken);
            return Mapper.Map<SmiteClientResponse, SmiteClientResponseModel>(result);
        }

        public async Task<CreateSmiteSessionResponseModel?> CreateSmiteSessionAsync(
            CreateSmiteSessionRequest createSmiteSessionRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(createSmiteSessionRequest);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetAsync<CreateSmiteSessionResponse>(url, cancellationToken);
            return Mapper.Map<CreateSmiteSessionResponse, CreateSmiteSessionResponseModel>(result);
        }

        public async Task<SmiteClientResponseModel?> TestSmiteSessionAsync(
            TestSmiteSessionRequest testSmiteSessionRequest, CancellationToken cancellationToken)
        {
            var url = ConstructUrl(testSmiteSessionRequest);
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var result = await GetAsync(url, cancellationToken);
            return Mapper.Map<SmiteClientResponse, SmiteClientResponseModel>(result);
        }
    }
}
