using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Application.Core.Business.Mappers;

internal class CreateAbilityRankMapper : Mapper<CommonItemDto, CreateAbilityRankDto>
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
