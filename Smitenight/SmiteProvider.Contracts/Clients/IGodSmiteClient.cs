using Smitenight.Domain.Models.Clients.GodClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface IGodSmiteClient
{
    Task<IEnumerable<GodDto>> GetGodsAsync(LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);

    Task<IEnumerable<GodLeaderbordDto>> GetGodLeaderbordAsync(int godId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default);

    Task<IEnumerable<GodAltAbilityDto>> GetGodAltAbilitiesAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<GodSkinDto>> GetGodSkinsAsync(int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);
}