using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Contracts.Contracts;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Persistence.Data.EntityFramework.Mappers
{
    public class AbilityMapper : Mapper<CreateAbilityDto, Ability>
    {
        private readonly IMapper<CreateAbilityRankDto, AbilityRank> _abilityRankMapper;
        private readonly IMapper<CreateAbilityTagDto, AbilityTag> _abilityTagMapper;

        public AbilityMapper(
            IMapper<CreateAbilityRankDto, AbilityRank> abilityRankMapper,
            IMapper<CreateAbilityTagDto, AbilityTag> abilityTagMapper)
        {
            _abilityRankMapper = abilityRankMapper;
            _abilityTagMapper = abilityTagMapper;
        }

        public override Ability Map(CreateAbilityDto input)
        {
            return new Ability
            {
                SmiteId = input.SmiteId,
                AbilityType = input.AbilityType,
                Cooldown = input.Cooldown,
                Description = input.Description,
                Checksum = input.Checksum,
                Cost = input.Cost,
                Summary = input.Summary,
                Url = input.Url,
                AbilityRanks = input.AbilityRanks.Select(_abilityRankMapper.Map).ToList(),
                AbilityTags = input.AbilityTags.Select(_abilityTagMapper.Map).ToList(),
                Latest = true // If we map it from a CreateDto, it's always the latest
            };
        }
    }
}
