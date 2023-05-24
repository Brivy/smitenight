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
            var abilityTagEntities = _mapperService.Map<IEnumerable<CreateAbilityTagDto>, IEnumerable<AbilityTag>>(abilityTags);
            var abilityRankEntities = _mapperService.Map<IEnumerable<CreateAbilityRankDto>, IEnumerable<AbilityRank>>(abilityRanks);

            abilityEntity.AbilityTags = abilityTagEntities;
            abilityEntity.AbilityRanks = abilityRankEntities;

            _dbContext.Abilities.Add(abilityEntity);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task CreateBasicAttackAsync(int godId, IEnumerable<CreateBasicAttackDto> basicAttacks, CancellationToken cancellationToken = default)
        {
            var basicAttackEntities = _mapperService.Map<IEnumerable<CreateBasicAttackDto>, IEnumerable<BasicAttack>>(basicAttacks);
            _dbContext.BasicAttacks.AddRange(basicAttackEntities);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> CreateGodAsync(CreateGodDto god, CancellationToken cancellationToken = default)
        {
            var godEntity = _mapperService.Map<CreateGodDto, God>(god);
            _dbContext.Gods.Add(godEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return godEntity.Id;
        }

        public Task CreateGodSkinAsync(int godId, CreateGodSkinDto godSkin, CancellationToken cancellationToken = default)
        {
            var godSkinEntity = _mapperService.Map<CreateGodSkinDto, GodSkin>(godSkin);
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
                    BasicAttackChecksum = x.BasicAttackChecksum,
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

        public async Task UpdateBasicAttackRelationAsync(int godId, CancellationToken cancellationToken = default)
        {
            var existingBasicAttackEntities = await _dbContext.BasicAttacks.Where(x => x.GodId == godId).ToListAsync(cancellationToken);
            foreach (var existingBasicAttackEntity in existingBasicAttackEntities)
            {
                existingBasicAttackEntity.GodId = godId;
            }

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
