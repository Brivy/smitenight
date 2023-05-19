using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;

namespace Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance
{
    public interface IMaintainGodsService
    {
        Task CreateAbility(int godId, AbilityDetailsDto ability, CancellationToken cancellationToken = default);
        Task CreateBasicAttacksAsync(int godId, IEnumerable<CommonItemDto> basicAttacks, CancellationToken cancellationToken = default);
        Task<int> CreateGodAsync(GodDto god, CancellationToken cancellationToken = default);
        Task CreateGodSkinAsync(int godId, GodSkinDto godSkin, CancellationToken cancellationToken = default);
        Task<IEnumerable<GodChecksumsDto>> GetGodChecksumsAsync(CancellationToken cancellationToken = default);
        Task MaintainAbilitiesAsync(int godId, bool godUpdated, Dictionary<string, AbilityDetailsDto> abilityChecksums, CancellationToken cancellationToken = default);
        Task MaintainBasicAttacksAsync(int godId, bool godUpdated, IEnumerable<CommonItemDto> basicAttacks, string checksum, CancellationToken cancellationToken = default);
        Task<int?> MaintainGodAsync(GodDto god, string checksum, CancellationToken cancellationToken = default);
        Task MaintainGodSkinsAsync(int godId, bool godUpdated, IEnumerable<GodSkinDto> godSkins, IEnumerable<string> checksums, CancellationToken cancellationToken = default);
    }
}