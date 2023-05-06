using Smitenight.Domain.Models.Clients.GodClient;
using Smitenight.Domain.Models.Clients.SmiteClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Application.Blazor.Business.Contracts.Facades.SmiteClient;

public interface IGodSmiteClientFacade
{
    Task<SmiteClientListResponse<GodsResponse>?> GetGodsAsync(LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<GodLeaderbordResponse>?> GetGodLeaderbordAsync(int godId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<GodAltAbilitiesResponse>?> GetGodAltAbilitiesAsync(CancellationToken cancellationToken = default);
    Task<SmiteClientListResponse<GodSkinsResponse>?> GetGodSkinsAsync(int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);
}