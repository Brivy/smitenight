using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Persistence.Data.EntityFramework.Mappers
{
    public class AbilityMapper : Mapper<CreateAbilityDto, Ability>
    {
        public override Ability Map(CreateAbilityDto input)
        {
            return new Ability
            {
                SmiteId = input.SmiteId,
                AbilityType = input.AbilityType,
                Cooldown = input.Cooldown,
                Description = input.Description,
                Checksum = input.Checksum,
                Cost = input.Cost,
                Summary = input.Summary,
                Url = input.Url
            };
        }
    }
}
