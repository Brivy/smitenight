using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Application.Blazor.Business.Services.Mappers
{
    public class CreateAbilityRankMapper : Mapper<RankItemDto, CreateAbilityRankDto>
    {
        public override CreateAbilityRankDto Map(RankItemDto rankItem)
        {
            return new CreateAbilityRankDto
            {
                Description = rankItem.Description,
                Value = rankItem.Value
            };
        }
    }
}
