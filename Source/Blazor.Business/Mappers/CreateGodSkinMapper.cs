using Smitenight.Application.Blazor.Business.Constants;
using Smitenight.Application.Blazor.Business.Contracts.Services.Checksums;
using Smitenight.Persistence.Data.Contracts.Enums;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Application.Blazor.Business.Mappers
{
    public class CreateGodSkinMapper : Mapper<GodSkinDto, CreateGodSkinDto>
    {
        private readonly IChecksumService _checksumService;

        public CreateGodSkinMapper(IChecksumService checksumService)
        {
            _checksumService = checksumService;
        }

        public override CreateGodSkinDto Map(GodSkinDto godSkin)
        {
            var checksum = _checksumService.CalculateChecksum(godSkin);
            return new CreateGodSkinDto
            {
                Checksum = checksum,
                GodSkinUrl = !string.IsNullOrWhiteSpace(godSkin.GodSkinUrl) ? godSkin.GodSkinUrl : null,
                Name = godSkin.SkinName,
                Obtainability = ConvertToGodSkinsObtainability(godSkin.Obtainability),
                PriceFavor = godSkin.PriceFavor,
                PriceGems = godSkin.PriceGems,
                SecondarySmiteId = godSkin.SkinId2,
                SmiteId = godSkin.SkinId1
            };
        }

        private static GodSkinsObtainability ConvertToGodSkinsObtainability(string obtainability) => obtainability switch
        {
            GodConstants.NormalObtainability => GodSkinsObtainability.Normal,
            GodConstants.CrossoverObtainability => GodSkinsObtainability.Crossover,
            GodConstants.LimitedObtainability => GodSkinsObtainability.Limited,
            GodConstants.ExclusiveObtainability => GodSkinsObtainability.Exclusive,
            _ => GodSkinsObtainability.Unknown
        };
    }
}
