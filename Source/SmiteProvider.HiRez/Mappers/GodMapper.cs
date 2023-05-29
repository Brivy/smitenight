using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Contracts;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class GodMapper : Mapper<God, GodDto>
    {
        private readonly IMapper<AbilityDetails, AbilityDetailsDto> _abilityDetailsMapper;
        private readonly IMapper<AbilityDescription, AbilityDescriptionDto> _abilityDescriptionMapper;
        private readonly IMapper<BasicAttack, BasicAttackDto> _basicAttackMapper;

        public GodMapper(
            IMapper<AbilityDetails, AbilityDetailsDto> abilityDetailsMapper,
            IMapper<AbilityDescription, AbilityDescriptionDto> abilityDescriptionMapper,
            IMapper<BasicAttack, BasicAttackDto> basicAttackMapper)
        {
            _abilityDetailsMapper = abilityDetailsMapper;
            _abilityDescriptionMapper = abilityDescriptionMapper;
            _basicAttackMapper = basicAttackMapper;
        }

        public override GodDto Map(God input)
        {
            return new GodDto
            {
                Ability1 = input.Ability1 ?? string.Empty,
                Ability2 = input.Ability2 ?? string.Empty,
                Ability3 = input.Ability3 ?? string.Empty,
                Ability4 = input.Ability4 ?? string.Empty,
                Ability5 = input.Ability5 ?? string.Empty,
                AbilityId1 = input.AbilityId1,
                AbilityId2 = input.AbilityId2,
                AbilityId3 = input.AbilityId3,
                AbilityId4 = input.AbilityId4,
                AbilityId5 = input.AbilityId5,
                AbilityDetails1 = _abilityDetailsMapper.Map(input.AbilityDetails1),
                AbilityDetails2 = _abilityDetailsMapper.Map(input.AbilityDetails2),
                AbilityDetails3 = _abilityDetailsMapper.Map(input.AbilityDetails3),
                AbilityDetails4 = _abilityDetailsMapper.Map(input.AbilityDetails4),
                AbilityDetails5 = _abilityDetailsMapper.Map(input.AbilityDetails5),
                AttackSpeed = input.AttackSpeed,
                AttackSpeedPerLevel = input.AttackSpeedPerLevel,
                AutoBanned = input.AutoBanned ?? string.Empty,
                Cons = input.Cons ?? string.Empty,
                Hp5PerLevel = input.Hp5PerLevel,
                Health = input.Health,
                HealthPerFive = input.HealthPerFive,
                HealthPerLevel = input.HealthPerLevel,
                Lore = input.Lore ?? string.Empty,
                Mp5PerLevel = input.Mp5PerLevel,
                MagicProtection = input.MagicProtection,
                MagicProtectionPerLevel = input.MagicProtectionPerLevel,
                MagicalPower = input.MagicalPower,
                MagicalPowerPerLevel = input.MagicalPowerPerLevel,
                Mana = input.Mana,
                ManaPerFive = input.ManaPerFive,
                ManaPerLevel = input.ManaPerLevel,
                Name = input.Name ?? string.Empty,
                OnFreeRotation = input.OnFreeRotation ?? string.Empty,
                Pantheon = input.Pantheon ?? string.Empty,
                PhysicalPower = input.PhysicalPower,
                PhysicalPowerPerLevel = input.PhysicalPowerPerLevel,
                PhysicalProtection = input.PhysicalProtection,
                PhysicalProtectionPerLevel = input.PhysicalProtectionPerLevel,
                Pros = input.Pros ?? string.Empty,
                Roles = input.Roles ?? string.Empty,
                Speed = input.Speed,
                Title = input.Title ?? string.Empty,
                Type = input.Type ?? string.Empty,
                AbilityDescription1 = _abilityDescriptionMapper.Map(input.AbilityDescription1),
                AbilityDescription2 = _abilityDescriptionMapper.Map(input.AbilityDescription2),
                AbilityDescription3 = _abilityDescriptionMapper.Map(input.AbilityDescription3),
                AbilityDescription4 = _abilityDescriptionMapper.Map(input.AbilityDescription4),
                AbilityDescription5 = _abilityDescriptionMapper.Map(input.AbilityDescription5),
                BasicAttack = _basicAttackMapper.Map(input.BasicAttack),
                GodAbility1Url = input.GodAbility1Url ?? string.Empty,
                GodAbility2Url = input.GodAbility2Url ?? string.Empty,
                GodAbility3Url = input.GodAbility3Url ?? string.Empty,
                GodAbility4Url = input.GodAbility4Url ?? string.Empty,
                GodAbility5Url = input.GodAbility5Url ?? string.Empty,
                GodCardUrl = input.GodCardUrl ?? string.Empty,
                GodIconUrl = input.GodIconUrl ?? string.Empty,
                Id = input.Id,
                LatestGod = input.LatestGod ?? string.Empty,
                RetMsg = input.RetMsg ?? string.Empty
            };
        }
    }
}
