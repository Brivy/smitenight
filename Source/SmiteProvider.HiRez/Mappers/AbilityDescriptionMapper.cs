using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.Common;
using Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient;
using Smitenight.Utilities.Mapper.Contracts.Contracts;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

internal class AbilityDescriptionMapper(IMapper<CommonItem, CommonItemDto> commonItemMapper) : Mapper<AbilityDescription, AbilityDescriptionDto>
{
    private readonly IMapper<CommonItem, CommonItemDto> _commonItemMapper = commonItemMapper;

    public override AbilityDescriptionDto Map(AbilityDescription input)
    {
        ItemDescription itemDescription = input.ItemDescription;
        return new AbilityDescriptionDto
        {
            Cooldown = itemDescription.Cooldown ?? string.Empty,
            Cost = itemDescription.Cost ?? string.Empty,
            Description = itemDescription.Description ?? string.Empty,
            AbilityRanks = itemDescription.AbilityRanks.Select(_commonItemMapper.Map).ToArray(),
            AbilityTags = itemDescription.AbilityTags.Select(_commonItemMapper.Map).ToArray()
        };
    }
}
