using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.OtherClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.OtherResponses;
using SmitenightApp.Infrastructure.SmiteClient.Models;
using SmitenightApp.Infrastructure.SmiteClient.Secrets;
using SmitenightApp.Infrastructure.SmiteClient.Settings;

namespace SmitenightApp.Infrastructure.SmiteClient.Clients
{
    public class OtherSmiteSmiteClient : SmiteClient, IOtherSmiteClient
    {
        public OtherSmiteSmiteClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<EsportProLeagueResponse>?> GetEsportProLeagueAsync(
            string sessionId, CancellationToken cancellationToken = default)
        {
            var request = new SmiteClientRequest(MethodNameConstants.EsportProLeagueMethod, sessionId);
            var result = await GetListAsync<EsportProLeagueResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<EsportProLeagueResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MotdResponse>?> GetMotdAsync(
            string sessionId, CancellationToken cancellationToken = default)
        {
            var request = new SmiteClientRequest(MethodNameConstants.MotdMethod, sessionId);
            var result = await GetListAsync<MotdResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MotdResponse>>(result);
        }
    }
}
