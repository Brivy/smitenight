using Smitenight.Domain.Models.Clients.GodClient;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.SmiteClient;

public interface IGodSmiteClient
{
    Task<SmiteClientListResponse<GodsResponse>?> GetGodsAsync(
       string sessionId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<GodLeaderbordResponse>?> GetGodLeaderbordAsync(
        string sessionId, int godId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<GodAltAbilitiesResponse>?> GetGodAltAbilitiesAsync(
        string sessionId, CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<GodSkinsResponse>?> GetGodSkinsAsync(
        string sessionId, int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);
}