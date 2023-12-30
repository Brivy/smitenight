using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Application.Core.Business.Mappers;

internal class CreateGodBasicAttackMapper : Mapper<CommonItemDto, CreateGodBasicAttackDto>
{
    public override CreateGodBasicAttackDto Map(CommonItemDto godBasicAttack)
    {
        return new CreateGodBasicAttackDto
        {
            Description = godBasicAttack.Description,
            Value = godBasicAttack.Value
        };
    }
}
