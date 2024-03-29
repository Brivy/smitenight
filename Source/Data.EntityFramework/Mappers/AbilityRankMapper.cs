﻿using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Persistence.Data.EntityFramework.Mappers;

internal class AbilityRankMapper : Mapper<CreateAbilityRankDto, AbilityRank>
{
    public override AbilityRank Map(CreateAbilityRankDto input)
    {
        return new AbilityRank
        {
            Description = input.Description,
            Value = input.Value
        };
    }
}
