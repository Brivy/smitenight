using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.ItemClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class GodRecommendedItemMapper : Mapper<GodRecommendedItem, GodRecommendedItemDto>
    {
        public override GodRecommendedItemDto Map(GodRecommendedItem input)
        {
            return new GodRecommendedItemDto
            {
                Category = input.Category ?? string.Empty,
                CategoryValueId = input.CategoryValueId,
                GodId = input.GodId,
                GodName = input.GodName ?? string.Empty,
                IconId = input.IconId,
                Item = input.Item ?? string.Empty,
                ItemId = input.ItemId,
                Role = input.Role ?? string.Empty,
                RoleValueId = input.RoleValueId,
                RetMsg = input.RetMsg ?? string.Empty
            };
        }
    }
}
