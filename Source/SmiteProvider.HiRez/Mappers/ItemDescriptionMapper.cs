﻿using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.Common;
using Smitenight.Providers.SmiteProvider.HiRez.Models.ItemClient;
using Smitenight.Utilities.Mapper.Contracts.Contracts;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

internal class ItemDescriptionMapper(IMapper<CommonItem, CommonItemDto> commonItemMapper) : Mapper<ItemDescription, ItemDescriptionDto>
{
    private readonly IMapper<CommonItem, CommonItemDto> _commonItemMapper = commonItemMapper;

    public override ItemDescriptionDto Map(ItemDescription input)
    {
        return new ItemDescriptionDto
        {
            Description = input.Description ?? string.Empty,
            SecondaryDescription = input.SecondaryDescription ?? string.Empty,
            ItemSubDescriptions = input.ItemSubDescriptions.Select(_commonItemMapper.Map).ToArray()
        };
    }
}
