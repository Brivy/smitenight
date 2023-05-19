using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Providers.SmiteProvider.HiRez.Models.Common;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class CommonItemMapper : Mapper<CommonItem, CommonItemDto>
    {
        public override CommonItemDto Map(CommonItem input)
        {
            return new CommonItemDto
            {
                Description = input.Description ?? string.Empty,
                Value = input.Value ?? string.Empty
            };
        }
    }
}
