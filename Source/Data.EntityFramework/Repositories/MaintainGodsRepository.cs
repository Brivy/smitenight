using Microsoft.EntityFrameworkCore;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.Contracts.Repositories;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Common.Services;

namespace Smitenight.Persistence.Data.EntityFramework.Repositories
{
    public class MaintainGodsRepository : IMaintainGodsRepository
    {
        private readonly SmitenightDbContext _dbContext;
        private readonly IMapperService _mapperService;

        public MaintainGodsRepository(
            SmitenightDbContext smitenightDbContext,
            IMapperService mapperService)
        {
            _dbContext = smitenightDbContext;
            _mapperService = mapperService;
        }

        public Task CreateAbilityAsync(int godId, CreateAbilityDto ability, IEnumerable<CreateAbilityTagDto> abilityTags, IEnumerable<CreateAbilityRankDto> abilityRanks, CancellationToken cancellationToken = default)
        {
            var abilityEntity = _mapperService.Map<CreateAbilityDto, Ability>(ability);
            var abilityTagEntities = _mapperService.MapAll<CreateAbilityTagDto, AbilityTag>(abilityTags);
            var abilityRankEntities = _mapperService.MapAll<CreateAbilityRankDto, AbilityRank>(abilityRanks);

            abilityEntity.GodId = godId;
            abilityEntity.AbilityTags = abilityTagEntities;
            abilityEntity.AbilityRanks = abilityRankEntities;

            _dbContext.Abilities.Add(abilityEntity);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> CreateGodAsync(CreateGodDto god, IEnumerable<CreateGodBasicAttackDto> godBasicAttacks, CancellationToken cancellationToken = default)
        {
            var godEntity = _mapperService.Map<CreateGodDto, God>(god);
            var godBasicAttackEntities = _mapperService.MapAll<CreateGodBasicAttackDto, GodBasicAttack>(godBasicAttacks);

            godEntity.GodBasicAttacks = godBasicAttackEntities;

            _dbContext.Gods.Add(godEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return godEntity.Id;
        }

        public Task CreateGodSkinAsync(int godId, CreateGodSkinDto godSkin, CancellationToken cancellationToken = default)
        {
            var godSkinEntity = _mapperService.Map<CreateGodSkinDto, GodSkin>(godSkin);
            godSkinEntity.GodId = godId;

            _dbContext.GodSkins.Add(godSkinEntity);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<GodChecksumsDto>> GetGodChecksumsAsync(CancellationToken cancellationToken = default)
        {
            var godChecksums = await _dbContext.Gods
                .Include(x => x.Abilities)
                .Include(x => x.GodSkins)
                .Select(x => new GodChecksumsDto
                {
                    GodId = x.Id,
                    SmiteGodId = x.SmiteId,
                    GodChecksum = x.Checksum,
                    Ability1Checksum = x.Abilities.Single(y => y.AbilityType == Contracts.Enums.AbilityType.Primary).Checksum,
                    Ability2Checksum = x.Abilities.Single(y => y.AbilityType == Contracts.Enums.AbilityType.Secondary).Checksum,
                    Ability3Checksum = x.Abilities.Single(y => y.AbilityType == Contracts.Enums.AbilityType.Tertiary).Checksum,
                    Ability4Checksum = x.Abilities.Single(y => y.AbilityType == Contracts.Enums.AbilityType.Ultimate).Checksum,
                    Ability5Checksum = x.Abilities.Single(y => y.AbilityType == Contracts.Enums.AbilityType.Passive).Checksum,
                    GodSkinChecksums = x.GodSkins.Select(y => y.Checksum).ToList()
                }).ToListAsync(cancellationToken);

            return godChecksums;
        }

        public async Task UpdateAbilityRelationAsync(int godId, int abilityId, CancellationToken cancellationToken = default)
        {
            var existingAbilityEntity = await _dbContext.Abilities.SingleAsync(x => x.SmiteId == abilityId, cancellationToken);
            existingAbilityEntity.GodId = godId;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateGodSkinRelationAsync(int godId, int godSkinId1, int godSkinId2, CancellationToken cancellationToken = default)
        {
            var existingGodSkinEntity = await _dbContext.GodSkins.SingleAsync(x => x.SmiteId == godSkinId1 && x.SecondarySmiteId == godSkinId2, cancellationToken);
            existingGodSkinEntity.GodId = godId;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
