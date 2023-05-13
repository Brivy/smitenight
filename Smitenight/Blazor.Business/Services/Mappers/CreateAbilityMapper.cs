using Smitenight.Persistence.Data.Contracts.Enums;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Application.Blazor.Business.Services.Mappers
{
    public class CreateAbilityMapper : Mapper<AbilityDetailsDto, CreateAbilityDto>
    {
        public override CreateAbilityDto Map(AbilityDetailsDto ability)
        {
            return new CreateAbilityDto
            {
                AbilityType = AbilityType.Primary,
                Cooldown = !string.IsNullOrWhiteSpace(ability.Description.ItemDescription.Cooldown) ? ability.Description.ItemDescription.Cooldown : null,
                Cost = !string.IsNullOrWhiteSpace(ability.Description.ItemDescription.Cost) ? ability.Description.ItemDescription.Cost : null,
                Description = ability.Description.ItemDescription.Description,
                SmiteId = ability.Id,
                Summary = ability.Summary,
                Url = ability.Url
            };
        }
    }
}
