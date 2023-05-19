using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Application.Blazor.Business.Services.Mappers
{
    public class CreateAbilityRankMapper : Mapper<CommonItemDto, CreateAbilityRankDto>
    {
        public override CreateAbilityRankDto Map(CommonItemDto rankItem)
        {
            return new CreateAbilityRankDto
            {
                Description = rankItem.Description,
                Value = rankItem.Value
            };
        }
    }
}
