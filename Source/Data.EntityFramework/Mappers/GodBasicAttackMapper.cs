using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Persistence.Data.EntityFramework.Mappers
{
    public class GodBasicAttackMapper : Mapper<CreateGodBasicAttackDto, GodBasicAttack>
    {
        public override GodBasicAttack Map(CreateGodBasicAttackDto input)
        {
            return new GodBasicAttack
            {
                Value = input.Value,
                Description = input.Description
            };
        }
    }
}
