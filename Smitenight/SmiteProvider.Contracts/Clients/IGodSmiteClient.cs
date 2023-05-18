using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface IGodSmiteClient
{
    Task<IEnumerable<GodDto>> GetGodsAsync(LanguageCode languageCode, CancellationToken cancellationToken = default);

    Task<IEnumerable<GodLeaderboardDto>> GetGodLeaderboardAsync(int godId, GameModeQueue gameModeQueue, CancellationToken cancellationToken = default);

    Task<IEnumerable<GodAltAbilityDto>> GetGodAltAbilitiesAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<GodSkinDto>> GetGodSkinsAsync(int godId, LanguageCode languageCode, CancellationToken cancellationToken = default);
}