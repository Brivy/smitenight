﻿using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Persistence.Data.EntityFramework.Mappers
{
    public class AbilityTagMapper : Mapper<CreateAbilityTagDto, AbilityTag>
    {
        public override AbilityTag Map(CreateAbilityTagDto input)
        {
            return new AbilityTag
            {
                Description = input.Description,
                Value = input.Value
            };
        }
    }
}
