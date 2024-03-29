﻿using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Application.Core.Business.Mappers;

internal class CreateAbilityTagMapper : Mapper<CommonItemDto, CreateAbilityTagDto>
{
    public override CreateAbilityTagDto Map(CommonItemDto abilityTag)
    {
        return new CreateAbilityTagDto
        {
            Description = abilityTag.Description,
            Value = abilityTag.Value
        };
    }
}
