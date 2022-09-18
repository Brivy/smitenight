using SmitenightApp.Domain.Clients.GodClient;
using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

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