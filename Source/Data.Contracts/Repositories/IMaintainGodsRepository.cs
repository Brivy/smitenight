using Smitenight.Persistence.Data.Contracts.Models;

namespace Smitenight.Persistence.Data.Contracts.Repositories
{
    public interface IMaintainGodsRepository
    {
        Task<IEnumerable<GodChecksumsDto>> GetGodChecksumsAsync(CancellationToken cancellationToken = default);
        Task<int> CreateGodAsync(CreateGodDto god, IEnumerable<CreateGodBasicAttackDto> godBasicAttacks, CancellationToken cancellationToken = default);
        Task CreateAbilityAsync(int godId, CreateAbilityDto ability, IEnumerable<CreateAbilityTagDto> abilityTags, IEnumerable<CreateAbilityRankDto> abilityRanks, CancellationToken cancellationToken = default);
        Task CreateGodSkinAsync(int godId, CreateGodSkinDto godSkin, CancellationToken cancellationToken = default);
        Task UpdateAbilityRelationAsync(int godId, int abilityId, CancellationToken cancellationToken = default);
        Task UpdateGodSkinRelationAsync(int godId, int godSkinId1, int godSkinId2, CancellationToken cancellationToken = default);
    }
}
