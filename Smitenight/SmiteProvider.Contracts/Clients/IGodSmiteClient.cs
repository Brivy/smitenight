using Smitenight.Domain.Models.Clients.GodClient;
using Smitenight.Domain.Models.Enums.SmiteClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface IGodSmiteClient
{
    Task<IEnumerable<God>> GetGodsAsync(LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);

    Task<IEnumerable<GodLeaderbord>> GetGodLeaderbordAsync(int godId, GameModeQueueIdEnum gameModeQueueId, CancellationToken cancellationToken = default);

    Task<IEnumerable<GodAltAbility>> GetGodAltAbilitiesAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<GodSkin>> GetGodSkinsAsync(int godId, LanguageCodeEnum languageCode, CancellationToken cancellationToken = default);
}