using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Application.Blazor.Business.Mappers
{
    public class CreateGodBasicAttackMapper : Mapper<CommonItemDto, CreateGodBasicAttackDto>
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
}
