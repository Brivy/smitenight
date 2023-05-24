using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Persistence.Data.EntityFramework.Mappers
{
    public class BasicAttackMapper : Mapper<CreateBasicAttackDto, BasicAttack>
    {
        public override BasicAttack Map(CreateBasicAttackDto input)
        {
            return new BasicAttack
            {
                Value = input.Value,
                Description = input.Description
            };
        }
    }
}
