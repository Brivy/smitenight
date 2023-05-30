using Smitenight.Application.Blazor.Business.Contracts.Services.Checksums;
using Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.Contracts.Repositories;
using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Services;

namespace Smitenight.Application.Blazor.Business.Services.Maintenance
{
    public class MaintainGodsService : IMaintainGodsService
    {
        private readonly IMaintainGodsRepository _maintainGodsRepository;
        private readonly IChecksumService _checksumService;
        private readonly IMapperService _mapperService;

        public MaintainGodsService(
            IMaintainGodsRepository maintainGodsRepository,
            IChecksumService checksumService,
            IMapperService mapperService)
        {
            _maintainGodsRepository = maintainGodsRepository;
            _checksumService = checksumService;
            _mapperService = mapperService;
        }

        public async Task<int?> MaintainGodAsync(GodDto god, string checksum, CancellationToken cancellationToken = default)
        {
            // Make sure that we create a clean checksum of an smite god without the abilities interfering
            var strippedGod = god with
            {
                AbilityDetails1 = null!,
                AbilityDetails2 = null!,
                AbilityDetails3 = null!,
                AbilityDetails4 = null!,
                AbilityDetails5 = null!,
                AbilityDescription1 = null!,
                AbilityDescription2 = null!,
                AbilityDescription3 = null!,
                AbilityDescription4 = null!,
                AbilityDescription5 = null!,
            };

            if (!_checksumService.IsChecksumDifferent(checksum, strippedGod))
            {
                return null;
            }

            return await CreateGodAsync(god, cancellationToken);
        }

        public async Task MaintainAbilitiesAsync(int godId, bool godUpdated, Dictionary<string, AbilityDetailsDto> abilityChecksums, CancellationToken cancellationToken = default)
        {
            foreach (var abilityChecksum in abilityChecksums)
            {
                if (_checksumService.IsChecksumDifferent(abilityChecksum.Key, abilityChecksum.Value))
                {
                    await CreateAbility(godId, abilityChecksum.Value, cancellationToken);
                }
                else if (godUpdated)
                {
                    await _maintainGodsRepository.UpdateAbilityRelationAsync(godId, abilityChecksum.Value.Id, cancellationToken);
                }
            }
        }

        public async Task MaintainGodSkinsAsync(int godId, bool godUpdated, IEnumerable<GodSkinDto> godSkins, IEnumerable<string> checksums, CancellationToken cancellationToken = default)
        {
            foreach (var godSkin in godSkins)
            {
                var skinChecksum = _checksumService.CalculateChecksum(godSkin);
                if (!checksums.Any(x => x == skinChecksum))
                {
                    await CreateGodSkinAsync(godId, godSkin, cancellationToken);
                }
                else if (godUpdated)
                {
                    await _maintainGodsRepository.UpdateGodSkinRelationAsync(godId, godSkin.SkinId1, godSkin.SkinId2, cancellationToken);
                }
            }
        }

        public Task<IEnumerable<GodChecksumsDto>> GetGodChecksumsAsync(CancellationToken cancellationToken = default)
        {
            return _maintainGodsRepository.GetGodChecksumsAsync(cancellationToken);
        }

        public Task<int> CreateGodAsync(GodDto god, CancellationToken cancellationToken = default)
        {
            var createGod = _mapperService.Map<GodDto, CreateGodDto>(god);
            var createGodBasicAttack = CreateGodBasicAttacksAsync(god.GodBasicAttack.GodBasicAttackItems);
            return _maintainGodsRepository.CreateGodAsync(createGod, createGodBasicAttack, cancellationToken);
        }

        public Task CreateAbility(int godId, AbilityDetailsDto ability, CancellationToken cancellationToken = default)
        {
            var createdAbility = _mapperService.Map<AbilityDetailsDto, CreateAbilityDto>(ability);
            var createdAbilityRanks = CreateAbilityRanks(ability.AbilityRanks);
            var createdAbilityTags = CreateAbilityTags(ability.AbilityTags);
            return _maintainGodsRepository.CreateAbilityAsync(godId, createdAbility, createdAbilityTags, createdAbilityRanks, cancellationToken);
        }

        public Task CreateGodSkinAsync(int godId, GodSkinDto godSkin, CancellationToken cancellationToken = default)
        {
            var createdGodSkin = _mapperService.Map<GodSkinDto, CreateGodSkinDto>(godSkin);
            return _maintainGodsRepository.CreateGodSkinAsync(godId, createdGodSkin, cancellationToken);
        }

        private IEnumerable<CreateGodBasicAttackDto> CreateGodBasicAttacksAsync(IEnumerable<CommonItemDto> basicAttacks)
        {
            var createdBasicAttackDescriptions = new List<CreateGodBasicAttackDto>();
            foreach (var basicAttack in basicAttacks)
            {
                createdBasicAttackDescriptions.Add(_mapperService.Map<CommonItemDto, CreateGodBasicAttackDto>(basicAttack));
            }

            return createdBasicAttackDescriptions;
        }

        private IEnumerable<CreateAbilityRankDto> CreateAbilityRanks(IEnumerable<CommonItemDto> abilityRanks)
        {
            var createdAbilityRanks = new List<CreateAbilityRankDto>();
            foreach (var abilityRank in abilityRanks)
            {
                createdAbilityRanks.Add(_mapperService.Map<CommonItemDto, CreateAbilityRankDto>(abilityRank));
            }

            return createdAbilityRanks;
        }

        private IEnumerable<CreateAbilityTagDto> CreateAbilityTags(IEnumerable<CommonItemDto> abilityTags)
        {
            var createdAbilityTags = new List<CreateAbilityTagDto>();
            foreach (var abilityTag in abilityTags)
            {
                createdAbilityTags.Add(_mapperService.Map<CommonItemDto, CreateAbilityTagDto>(abilityTag));
            }

            return createdAbilityTags;
        }
    }
}
