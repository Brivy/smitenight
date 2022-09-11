using SmitenightApp.Abstractions.Application.System;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.GodResponses;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Application.Adapters
{
    public class GodSmiteClientAdapter
    {
        private readonly IGodSmiteClient _godSmiteClient;
        private readonly ISmiteSessionService _smiteSessionService;

        public GodSmiteClientAdapter(IGodSmiteClient godSmiteClient,
            ISmiteSessionService smiteSessionService)
        {
            _godSmiteClient = godSmiteClient;
            _smiteSessionService = smiteSessionService;
        }

        public async Task<SmiteClientListResponse<GodsResponse>?> GetGodsAsync(LanguageCodeEnum languageCode, CancellationToken cancellationToken)
        {
            var sessionId = await _smiteSessionService.GetSessionIdAsync(cancellationToken);
            return await _godSmiteClient.GetGodsAsync(sessionId, languageCode, cancellationToken);
        }

        public Task<SmiteClientListResponse<GodLeaderbordResponse>?> GetGodLeaderbordAsync(string sessionId, int godId, GameModeQueueIdEnum gameModeQueueId,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SmiteClientListResponse<GodAltAbilitiesResponse>?> GetGodAltAbilitiesAsync(string sessionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SmiteClientListResponse<GodSkinsResponse>?> GetGodSkinsAsync(string sessionId, int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
