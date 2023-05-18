using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class GodAltAbilityMapper : Mapper<GodAltAbilityMapper, GodAltAbilityDto>
    {
        public override GodAltAbilityDto Map(GodAltAbilityMapper input)
        {
            return new GodAltAbilityDto
            {
                Description = input.Description ?? string.Empty,
                Id = input.Id ?? string.Empty,
                Summary = input.Summary ?? string.Empty,
                URL = input.URL ?? string.Empty
            };
        }
    }
}
