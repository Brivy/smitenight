﻿using Microsoft.EntityFrameworkCore;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.Contracts.Repositories;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Services;

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

        public async Task CreateAbilityAsync(int godId, CreateAbilityDto ability, CancellationToken cancellationToken = default)
        {
            var abilityEntity = _mapperService.Map<CreateAbilityDto, Ability>(ability);
            var patchId = await GetLatestPatchIdAsync(cancellationToken);

            abilityEntity.GodId = godId;
            abilityEntity.PatchId = patchId;

            _dbContext.Abilities.Add(abilityEntity);

            var existingAbility = await _dbContext.Abilities.SingleOrDefaultAsync(x => x.SmiteId == ability.SmiteId && x.Latest, cancellationToken);
            if (existingAbility != null) existingAbility.Latest = false;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> CreateGodAsync(CreateGodDto god, CancellationToken cancellationToken = default)
        {
            var godEntity = _mapperService.Map<CreateGodDto, God>(god);
            var patchId = await GetLatestPatchIdAsync(cancellationToken);

            godEntity.PatchId = patchId;

            _dbContext.Gods.Add(godEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var existingGodEntity = await _dbContext.Gods.SingleOrDefaultAsync(x => x.SmiteId == god.SmiteId && x.Latest, cancellationToken);
            if (existingGodEntity != null) existingGodEntity.Latest = false;

            return godEntity.Id;
        }

        public async Task CreateGodSkinAsync(int godId, CreateGodSkinDto godSkin, CancellationToken cancellationToken = default)
        {
            var godSkinEntity = _mapperService.Map<CreateGodSkinDto, GodSkin>(godSkin);
            var patchId = await GetLatestPatchIdAsync(cancellationToken);

            godSkinEntity.GodId = godId;
            godSkinEntity.PatchId = patchId;

            _dbContext.GodSkins.Add(godSkinEntity);

            var existingGodSkin = await _dbContext.GodSkins.SingleOrDefaultAsync(x => x.SmiteId == godSkin.SmiteId && x.SecondarySmiteId == godSkin.SecondarySmiteId && x.Latest, cancellationToken);
            if (existingGodSkin != null) existingGodSkin.Latest = false;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<GodChecksumsDto>> GetGodChecksumsAsync(CancellationToken cancellationToken = default)
        {
            var godChecksums = await _dbContext.Gods
                .Include(x => x.Abilities.Where(y => y.Latest))
                .Include(x => x.GodSkins.Where(y => y.Latest))
                .Where(x => x.Latest)
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

        private Task<int> GetLatestPatchIdAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.Patches
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => x.Id)
                .FirstAsync(cancellationToken);
        }
    }
}
