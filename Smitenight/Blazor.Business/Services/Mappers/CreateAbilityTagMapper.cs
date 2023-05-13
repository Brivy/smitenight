using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Application.Blazor.Business.Services.Mappers
{
    public class CreateAbilityTagMapper : Mapper<MenuItemDto, CreateAbilityTagDto>
    {
        public override CreateAbilityTagDto Map(MenuItemDto abilityTag)
        {
            return new CreateAbilityTagDto
            {
                Description = abilityTag.Description,
                Value = abilityTag.Value
            };
        }
    }
}
