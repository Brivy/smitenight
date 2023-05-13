using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Application.Blazor.Business.Services.Mappers
{
    public class CreateBasicAttackDescriptionMapper : Mapper<BasicAttackItemDto, CreateBasicAttackDescriptionDto>
    {
        public override CreateBasicAttackDescriptionDto Map(BasicAttackItemDto basicAttack)
        {
            return new CreateBasicAttackDescriptionDto
            {
                Description = basicAttack.Description,
                Value = basicAttack.Value
            };
        }
    }
}
