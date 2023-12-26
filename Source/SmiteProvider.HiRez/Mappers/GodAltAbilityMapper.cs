using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

internal class GodAltAbilityMapper : Mapper<GodAltAbility, GodAltAbilityDto>
{
    public override GodAltAbilityDto Map(GodAltAbility input)
    {
        return new GodAltAbilityDto
        {
            AltName = input.AltName ?? string.Empty,
            AltPosition = input.AltPosition ?? string.Empty,
            God = input.God ?? string.Empty,
            GodId = input.GodId,
            ItemId = input.ItemId,
            RetMsg = input.RetMsg ?? string.Empty
        };
    }
}
