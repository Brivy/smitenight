using Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.Contracts.Repositories;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Services;

namespace Smitenight.Application.Blazor.Business.Services.Maintenance
{
    public class MaintainGodsService : IMaintainGodsService
    {
        private readonly IMaintainGodsRepository _maintainGodsRepository;
        private readonly IMapperService _mapperService;

        public MaintainGodsService(
            IMaintainGodsRepository maintainGodsRepository,
            IMapperService mapperService)
        {
            _maintainGodsRepository = maintainGodsRepository;
            _mapperService = mapperService;
        }

        public Task<IEnumerable<GodChecksumsDto>> GetGodChecksumsAsync(CancellationToken cancellationToken = default)
        {
            return _maintainGodsRepository.GetGodChecksumsAsync(cancellationToken);
        }

        public Task<int> CreateGodAsync(GodDto god, CancellationToken cancellationToken = default)
        {
            var createGod = _mapperService.Map<GodDto, CreateGodDto>(god);
            return _maintainGodsRepository.CreateGodAsync(createGod, cancellationToken);
        }

        public Task CreateAbility(int godId, AbilityDetailsDto ability, CancellationToken cancellationToken = default)
        {
            var createdAbility = _mapperService.Map<AbilityDetailsDto, CreateAbilityDto>(ability);
            var createdAbilityRanks = CreateAbilityRanks(ability.Description.ItemDescription.RankItems);
            var createdAbilityTags = CreateAbilityTags(ability.Description.ItemDescription.MenuItems);
            return _maintainGodsRepository.CreateAbilityAsync(godId, createdAbility, createdAbilityTags, createdAbilityRanks, cancellationToken);
        }

        public Task UpdateAbilityRelationAsync(int godId, IEnumerable<int> abilityIds, CancellationToken cancellationToken = default)
        {
            return _maintainGodsRepository.UpdateGodRelationAsync(godId, abilityIds, cancellationToken);
        }

        public Task CreateBasicAttacksAsync(int createdGodId, IEnumerable<BasicAttackItemDto> basicAttacks, CancellationToken cancellationToken = default)
        {
            var createdBasicAttackDescriptions = new List<CreateBasicAttackDescriptionDto>();
            foreach (var basicAttack in basicAttacks)
            {
                createdBasicAttackDescriptions.Add(_mapperService.Map<BasicAttackItemDto, CreateBasicAttackDescriptionDto>(basicAttack));
            }

            return _maintainGodsRepository.CreateBasicAttackAsync(createdGodId, createdBasicAttackDescriptions, cancellationToken);
        }

        public Task UpdateBasicAttackRelationAsync(int godId, CancellationToken cancellation = default)
        {
            return _maintainGodsRepository.UpdateBasicAttackRelationAsync(godId, cancellation);
        }

        public Task CreateGodSkinAsync(int godId, GodSkinDto godSkin, CancellationToken cancellationToken = default)
        {
            var createdGodSkin = _mapperService.Map<GodSkinDto, CreateGodSkinDto>(godSkin);
            return _maintainGodsRepository.CreateGodSkinAsync(godId, createdGodSkin, cancellationToken);
        }

        public Task UpdateGodSkinRelationAsync(int godId, IEnumerable<int> godSkinIds, CancellationToken cancellation = default)
        {
            return _maintainGodsRepository.UpdateBasicAttackRelationAsync(godId, cancellation);
        }

        private IEnumerable<CreateAbilityRankDto> CreateAbilityRanks(IEnumerable<RankItemDto> abilityRanks)
        {
            var createdAbilityRanks = new List<CreateAbilityRankDto>();
            foreach (var abilityRank in abilityRanks)
            {
                createdAbilityRanks.Add(_mapperService.Map<RankItemDto, CreateAbilityRankDto>(abilityRank));
            }

            return createdAbilityRanks;
        }

        private IEnumerable<CreateAbilityTagDto> CreateAbilityTags(IEnumerable<MenuItemDto> abilityTags)
        {
            var createdAbilityTags = new List<CreateAbilityTagDto>();
            foreach (var abilityTag in abilityTags)
            {
                createdAbilityTags.Add(_mapperService.Map<MenuItemDto, CreateAbilityTagDto>(abilityTag));
            }

            return createdAbilityTags;
        }
    }
}
