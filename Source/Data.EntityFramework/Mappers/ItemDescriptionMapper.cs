using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Persistence.Data.EntityFramework.Mappers
{
    public class ItemDescriptionMapper : Mapper<CreateItemDescriptionDto, ItemDescription>
    {
        public override ItemDescription Map(CreateItemDescriptionDto input)
        {
            return new ItemDescription
            {
                Description = input.Description,
                Value = input.Value
            };
        }
    }
}
