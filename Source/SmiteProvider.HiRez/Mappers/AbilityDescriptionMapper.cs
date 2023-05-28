using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class AbilityDescriptionIEnumerableMapper : Mapper<IEnumerable<AbilityDescription>, IEnumerable<AbilityDescriptionDto>>
    {

    }

    public class AbilityDescriptionMapper : Mapper<AbilityDescription, AbilityDescriptionDto>
    {
        //private readonly IMapperService _mapperService;

        //public AbilityDescriptionMapper(IMapperService mapperService)
        //{
        //    _mapperService = mapperService;
        //}

        public override AbilityDescriptionDto Map(AbilityDescription input)
        {
            var itemDescription = input.ItemDescription;
            return new AbilityDescriptionDto
            {
                Cooldown = itemDescription.Cooldown ?? string.Empty,
                Cost = itemDescription.Cost ?? string.Empty,
                Description = itemDescription.Description ?? string.Empty,
                //AbilityRanks = _mapperService.Map<CommonItem[], CommonItemDto[]>(itemDescription.AbilityRanks),
                //AbilityTags = _mapperService.Map<CommonItem[], CommonItemDto[]>(itemDescription.AbilityTags)
            };
        }
    }
}
