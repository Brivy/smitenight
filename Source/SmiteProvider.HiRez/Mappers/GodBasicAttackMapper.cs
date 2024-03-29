﻿using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.Common;
using Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient;
using Smitenight.Utilities.Mapper.Contracts.Contracts;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

internal class GodBasicAttackMapper(IMapper<CommonItem, CommonItemDto> commonItemMapper) : Mapper<GodBasicAttack, GodBasicAttackDto>
{
    private readonly IMapper<CommonItem, CommonItemDto> _commonItemMapper = commonItemMapper;

    public override GodBasicAttackDto Map(GodBasicAttack input)
    {
        GodBasicAttackDescription godBasicAttackDescription = input.ItemDescription;
        return new GodBasicAttackDto
        {
            Cooldown = godBasicAttackDescription.Cooldown ?? string.Empty,
            Cost = godBasicAttackDescription.Cost ?? string.Empty,
            Description = godBasicAttackDescription.Description ?? string.Empty,
            GodBasicAttackItems = godBasicAttackDescription.GodBasicAttackItems.Select(_commonItemMapper.Map).ToArray(),
            GodBasicAttackRanks = godBasicAttackDescription.GodBasicAttackRanks.Select(_commonItemMapper.Map).ToArray()
        };
    }
}
