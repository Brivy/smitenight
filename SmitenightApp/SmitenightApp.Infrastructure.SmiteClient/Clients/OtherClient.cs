using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.SmiteClient.Requests.OtherRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.OtherResponses;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.OtherResponses;
using SmitenightApp.Infrastructure.SmiteClient.Secrets;
using SmitenightApp.Infrastructure.SmiteClient.Settings;

namespace SmitenightApp.Infrastructure.SmiteClient.Clients
{
    public class OtherClient : SmiteClient, IOtherClient
    {
        public OtherClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<EsportProLeagueResponse>?> GetEsportProLeagueAsync(
            EsportProLeagueRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<EsportProLeagueRequest, EsportProLeagueResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<EsportProLeagueResponse>>(result);
        }

        public async Task<SmiteClientListResponse<MotdResponse>?> GetMotdAsync(
            MotdRequest request, CancellationToken cancellationToken)
        {
            var result = await GetListAsync<MotdRequest, MotdResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<MotdResponse>>(result);
        }
    }
}
