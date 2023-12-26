using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Persistence.Data.EntityFramework.Mappers;

internal class GodBasicAttackMapper : Mapper<CreateGodBasicAttackDto, GodBasicAttack>
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
