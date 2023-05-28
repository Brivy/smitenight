using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class AbilityDetailsMapper : Mapper<AbilityDetails, AbilityDetailsDto>
    {
        //private readonly IMapperService _mapperService;

        //public AbilityDetailsMapper(IMapperService mapperService)
        //{
        //    _mapperService = mapperService;
        //}

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
                //AbilityRanks = _mapperService.Map<CommonItem[], CommonItemDto[]>(itemDescription.AbilityRanks),
                //AbilityTags = _mapperService.Map<CommonItem[], CommonItemDto[]>(itemDescription.AbilityTags)
            };
        }
    }
}
