using Smitenight.Application.Blazor.Business.Constants;
using Smitenight.Persistence.Data.Contracts.Enums;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Application.Blazor.Business.Services.Mappers
{
    public class CreateGodSkinMapper : Mapper<GodSkinDto, CreateGodSkinDto>
    {
        public override CreateGodSkinDto Map(GodSkinDto godSkin)
        {
            return new CreateGodSkinDto
            {
                GodSkinUrl = !string.IsNullOrWhiteSpace(godSkin.GodSkinUrl) ? godSkin.GodSkinUrl : null,
                Name = godSkin.SkinName,
                Obtainability = ConvertToGodSkinsObtainabilityEnum(godSkin.Obtainability),
                PriceFavor = godSkin.PriceFavor,
                PriceGems = godSkin.PriceGems,
                SecondarySmiteId = godSkin.SkinId2,
                SmiteId = godSkin.SkinId1
            };
        }

        private GodSkinsObtainabilityEnum ConvertToGodSkinsObtainabilityEnum(string obtainability) => obtainability switch
        {
            GodConstants.NormalObtainability => GodSkinsObtainabilityEnum.Normal,
            GodConstants.CrossoverObtainability => GodSkinsObtainabilityEnum.Crossover,
            GodConstants.LimitedObtainability => GodSkinsObtainabilityEnum.Limited,
            GodConstants.ExclusiveObtainability => GodSkinsObtainabilityEnum.Exclusive,
            _ => GodSkinsObtainabilityEnum.Unknown
        };
    }
}
