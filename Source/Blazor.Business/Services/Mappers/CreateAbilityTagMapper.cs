using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Application.Blazor.Business.Services.Mappers
{
    public class CreateAbilityTagMapper : Mapper<CommonItemDto, CreateAbilityTagDto>
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
}
