using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;

namespace Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance
{
    public interface IMaintainGodsService
    {
        Task<IEnumerable<GodChecksumsDto>> GetGodChecksumsAsync(CancellationToken cancellationToken = default);
        Task CreateAbility(int createdGodId, AbilityDetailsDto ability, CancellationToken cancellationToken = default);
        Task UpdateAbilityRelationAsync(int createGodId, IEnumerable<int> abilityIds, CancellationToken cancellationToken = default);
        Task CreateBasicAttacksAsync(int createdGodId, IEnumerable<BasicAttackItemDto> basicAttacks, CancellationToken cancellationToken = default);
        Task UpdateBasicAttackRelationAsync(int godId, CancellationToken cancellation = default);
        Task<int> CreateGodAsync(GodDto god, CancellationToken cancellationToken = default);
        Task CreateGodSkinAsync(int createdGodId, GodSkinDto godSkin, CancellationToken cancellationToken = default);
        Task UpdateGodSkinRelationAsync(int godId, IEnumerable<int> godSkinIds, CancellationToken cancellation = default);
    }
}