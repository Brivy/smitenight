using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class GodSkinMapper : Mapper<GodSkin, GodSkinDto>
    {
        public override GodSkinDto Map(GodSkin input)
        {
            return new GodSkinDto
            {
                GodIconUrl = input.GodIconUrl ?? string.Empty,
                GodSkinUrl = input.GodSkinUrl ?? string.Empty,
                GodId = input.GodId,
                GodName = input.GodName ?? string.Empty,
                Obtainability = input.Obtainability ?? string.Empty,
                PriceFavor = input.PriceFavor,
                PriceGems = input.PriceGems,
                RetMsg = input.RetMsg ?? string.Empty,
                SkinId1 = input.SkinId1,
                SkinId2 = input.SkinId2,
                SkinName = input.SkinName ?? string.Empty
            };
        }
    }
}
