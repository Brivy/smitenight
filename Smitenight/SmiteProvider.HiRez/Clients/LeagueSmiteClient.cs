using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Domain.Models.Clients.LeagueClient;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Constants.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;
using Smitenight.Providers.SmiteProvider.HiRez.Contracts.LeagueResponses;
using Smitenight.Providers.SmiteProvider.HiRez.Models;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Providers.SmiteProvider.HiRez.Settings;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public class LeagueSmiteClient : SmiteClient, ILeagueSmiteClient
    {
        public LeagueSmiteClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientListResponse<LeagueLeaderboardResponse>?> GetLeagueLeaderboardAsync(
            string sessionId, GameModeQueueIdEnum gameModeQueueId, LeagueTierEnum leagueTier, int round, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath((int)gameModeQueueId, (int)leagueTier);
            var request = new SmiteClientRequest(MethodNameConstants.LeagueLeaderbordMethod, sessionId, urlPath);
            var result = await GetListAsync<LeagueLeaderboardResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<LeagueLeaderboardResponse>>(result);
        }

        public async Task<SmiteClientListResponse<LeagueSeasonsResponse>?> GetLeagueSeasonsAsync(
            string sessionId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default)
        {
            var urlPath = ConstructUrlPath((int)gameModeQueueId);
            var request = new SmiteClientRequest(MethodNameConstants.LeagueSeasonsMethod, sessionId, urlPath);
            var result = await GetListAsync<LeagueSeasonsResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientListResponse<LeagueSeasonsResponse>>(result);
        }
    }
}
