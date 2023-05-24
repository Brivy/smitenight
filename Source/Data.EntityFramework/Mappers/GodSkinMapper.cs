using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Persistence.Data.EntityFramework.Mappers
{
    public class GodSkinMapper : Mapper<CreateGodSkinDto, GodSkin>
    {
        public override GodSkin Map(CreateGodSkinDto input)
        {
            return new GodSkin
            {
                Checksum = input.Checksum,
                Name = input.Name,
                GodSkinUrl = input.GodSkinUrl,
                Obtainability = input.Obtainability,
                PriceFavor = input.PriceFavor,
                PriceGems = input.PriceGems,
                SecondarySmiteId = input.SecondarySmiteId,
                SmiteId = input.SmiteId
            };
        }
    }
}
