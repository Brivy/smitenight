using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.GodResponses;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface IGodSmiteClient
{
    Task<SmiteClientListResponse<GodsResponse>?> GetGodsAsync(
        string sessionId, LanguageCodeEnum languageCode, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<GodLeaderbordResponse>?> GetGodLeaderbordAsync(
        string sessionId, int godId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<GodAltAbilitiesResponse>?> GetGodAltAbilitiesAsync(
        string sessionId, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<GodSkinsResponse>?> GetGodSkinsAsync(
        string sessionId, int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken);
}