using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Application.Blazor.Business.Services.Mappers
{
    public class CreateBasicAttackDescriptionMapper : Mapper<CommonItemDto, CreateBasicAttackDto>
    {
        public override CreateBasicAttackDto Map(CommonItemDto basicAttack)
        {
            return new CreateBasicAttackDto
            {
                Description = basicAttack.Description,
                Value = basicAttack.Value
            };
        }
    }
}
