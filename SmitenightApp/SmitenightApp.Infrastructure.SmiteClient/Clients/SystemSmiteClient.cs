using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Abstractions.Infrastructure.System;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.SystemResponses;
using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.SystemResponses;
using SmitenightApp.Infrastructure.SmiteClient.Models;
using SmitenightApp.Infrastructure.SmiteClient.Secrets;
using SmitenightApp.Infrastructure.SmiteClient.Settings;

namespace SmitenightApp.Infrastructure.SmiteClient.Clients
{
    public class SystemSmiteClient : SmiteClient, ISystemSmiteClient
    {
        public SystemSmiteClient(HttpClient httpClient,
            ISmiteSessionService smiteSessionService,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteSessionService, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientResponse?> TestSmiteSessionAsync(
            string sessionId, CancellationToken cancellationToken)
        {
            var request = new SmiteClientRequest(MethodNameConstants.TestSessionMethod, sessionId);
            var result = await GetAsync(request, cancellationToken);
            return Mapper.Map<SmiteClientResponse>(result);
        }

        public async Task<SmiteClientListResponse<DataUsedResponse>?> GetDataUsedAsync(
            string sessionId, CancellationToken cancellationToken)
        {
            var request = new SmiteClientRequest(MethodNameConstants.DataUsedMethod, sessionId);
            var result = await GetListAsync<DataUsedResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<DataUsedResponse>>(result);
        }

        public async Task<SmiteClientListResponse<HirezServerStatusResponse>?> GetHirezServerStatusAsync(
            string sessionId, CancellationToken cancellationToken)
        {
            var request = new SmiteClientRequest(MethodNameConstants.HirezServerStatusMethod, sessionId);
            var result = await GetListAsync<HirezServerStatusResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<HirezServerStatusResponse>>(result);
        }

        public async Task<SmiteClientResponse<PatchInfoResponse>?> GetPatchInfoAsync(
            string sessionId, CancellationToken cancellationToken)
        {
            var request = new SmiteClientRequest(MethodNameConstants.PatchInfoMethod, sessionId);
            var result = await GetAsync<PatchInfoResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientResponse<PatchInfoResponse>>(result);
        }
    }
}
