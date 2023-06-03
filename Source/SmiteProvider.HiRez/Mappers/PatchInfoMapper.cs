using Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.SystemClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class PatchInfoMapper : Mapper<PatchInfo, PatchInfoDto>
    {
        public override PatchInfoDto Map(PatchInfo input)
        {
            return new PatchInfoDto
            {
                RetMsg = input.RetMsg,
                VersionString = input.VersionString ?? string.Empty
            };
        }
    }
}
