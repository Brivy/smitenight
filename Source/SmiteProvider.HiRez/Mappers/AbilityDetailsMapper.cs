using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.Common;
using Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient;
using Smitenight.Utilities.Mapper.Contracts.Contracts;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

internal class AbilityDetailsMapper(IMapper<CommonItem, CommonItemDto> commonItemMapper) : Mapper<AbilityDetails, AbilityDetailsDto>
{
    private readonly IMapper<CommonItem, CommonItemDto> _commonItemMapper = commonItemMapper;

    public override AbilityDetailsDto Map(AbilityDetails input)
    {
        ItemDescription itemDescription = input.Description.ItemDescription;
        return new AbilityDetailsDto
        {
            Id = input.Id,
            Summary = input.Summary ?? string.Empty,
            Url = input.Url ?? string.Empty,
            Cooldown = itemDescription.Cooldown ?? string.Empty,
            Cost = itemDescription.Cost ?? string.Empty,
            Description = itemDescription.Description ?? string.Empty,
            AbilityType = AbilityType.Unknown, // We don't have this information about the ability
            AbilityRanks = itemDescription.AbilityRanks.Select(_commonItemMapper.Map).ToArray(),
            AbilityTags = itemDescription.AbilityTags.Select(_commonItemMapper.Map).ToArray()
        };
    }
}
