﻿using Smitenight.Persistence.Data.Contracts.Models;

namespace Smitenight.Persistence.Data.Contracts.Repositories
{
    public interface IMaintainGodsRepository
    {
        Task<IEnumerable<GodChecksumsDto>> GetGodChecksumsAsync(CancellationToken cancellationToken = default);
        Task<int> CreateGodAsync(CreateGodDto god, CancellationToken cancellationToken = default);
        Task CreateAbilityAsync(int godId, CreateAbilityDto ability, IEnumerable<CreateAbilityTagDto> abilityTags, IEnumerable<CreateAbilityRankDto> abilityRanks, CancellationToken cancellationToken = default);
        Task CreateBasicAttackAsync(int godId, IEnumerable<CreateBasicAttackDescriptionDto> basicAttacks, CancellationToken cancellationToken = default);
        Task CreateGodSkinsAsync(int godId, IEnumerable<CreateGodSkinDto> godSkins, CancellationToken cancellationToken = default);
        Task UpdateGodRelationAsync(int godId, IEnumerable<int> abilityIds, CancellationToken cancellationToken = default);
    }
}
