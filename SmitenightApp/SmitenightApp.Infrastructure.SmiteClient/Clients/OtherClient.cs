using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Abstractions.Infrastructure.System;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.OtherResponses;
using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.OtherResponses;
using SmitenightApp.Infrastructure.SmiteClient.Models;
using SmitenightApp.Infrastructure.SmiteClient.Secrets;
using SmitenightApp.Infrastructure.SmiteClient.Settings;

namespace SmitenightApp.Infrastructure.SmiteClient.Clients
{
    public class OtherClient : SmiteClient, IOtherClient
    {
        public OtherClient(HttpClient httpClient,
            ISmiteSessionService smiteSessionService,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteSessionService, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<EsportProLeagueResponse>?> GetEsportProLeagueAsync(
            string sessionId, CancellationToken cancellationToken)
        {
            var request = new SmiteClientRequest(MethodNameConstants.EsportProLeagueMethod, sessionId);
            var result = await GetListAsync<EsportProLeagueResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<EsportProLeagueResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MotdResponse>?> GetMotdAsync(
            string sessionId, CancellationToken cancellationToken)
        {
            var request = new SmiteClientRequest(MethodNameConstants.MotdMethod, sessionId);
            var result = await GetListAsync<MotdResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MotdResponse>>(result);
        }
    }
}
