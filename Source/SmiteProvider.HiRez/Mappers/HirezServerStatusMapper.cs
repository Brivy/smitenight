using Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.SystemClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

internal class HirezServerStatusMapper : Mapper<HirezServerStatus, HirezServerStatusDto>
{
    public override HirezServerStatusDto Map(HirezServerStatus input)
    {
        return new HirezServerStatusDto
        {
            EntryDatetime = input.EntryDatetime ?? string.Empty,
            Environment = input.Environment ?? string.Empty,
            LimitedAccess = input.LimitedAccess,
            Platform = input.Platform ?? string.Empty,
            RetMsg = input.RetMsg ?? string.Empty,
            Status = input.Status ?? string.Empty,
            Version = input.Version ?? string.Empty
        };
    }
}
