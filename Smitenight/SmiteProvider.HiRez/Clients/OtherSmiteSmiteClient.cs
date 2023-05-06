using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Domain.Models.Clients.OtherClient;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;
using Smitenight.Providers.SmiteProvider.HiRez.Contracts.OtherResponses;
using Smitenight.Providers.SmiteProvider.HiRez.Models;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Providers.SmiteProvider.HiRez.Settings;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
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
