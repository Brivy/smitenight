﻿using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.Common;
using Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Contracts;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class AbilityDetailsMapper : Mapper<AbilityDetails, AbilityDetailsDto>
    {
        private readonly IMapper<CommonItem, CommonItemDto> _commonItemMapper;

        public AbilityDetailsMapper(IMapper<CommonItem, CommonItemDto> commonItemMapper)
        {
            _commonItemMapper = commonItemMapper;
        }

        public override AbilityDetailsDto Map(AbilityDetails input)
        {
            var itemDescription = input.Description.ItemDescription;
            return new AbilityDetailsDto
            {
                Id = input.Id,
                Summary = input.Summary ?? string.Empty,
                Url = input.Url ?? string.Empty,
                Cooldown = itemDescription.Cooldown ?? string.Empty,
                Cost = itemDescription.Cost ?? string.Empty,
                Description = itemDescription.Description ?? string.Empty,
                AbilityRanks = itemDescription.AbilityRanks.Select(_commonItemMapper.Map).ToArray(),
                AbilityTags = itemDescription.AbilityTags.Select(_commonItemMapper.Map).ToArray()
            };
        }
    }
}
