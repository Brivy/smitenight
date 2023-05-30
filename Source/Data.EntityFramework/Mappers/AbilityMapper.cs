﻿using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Common.Contracts;
using Smitenight.Utilities.Mapper.Common.Models;

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
                AbilityRanks = input.AbilityRanks.Select(x => _abilityRankMapper.Map(x)).ToList(),
                AbilityTags = input.AbilityTags.Select(x => _abilityTagMapper.Map(x)).ToList()
            };
        }
    }
}
