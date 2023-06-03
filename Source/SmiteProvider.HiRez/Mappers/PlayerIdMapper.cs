using Smitenight.Providers.SmiteProvider.Contracts.Models.RetrievePlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.RetrievePlayerClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class PlayerIdMapper : Mapper<PlayerId, PlayerIdDto>
    {
        public override PlayerIdDto Map(PlayerId input)
        {
            return new PlayerIdDto
            {
                PlayerId = input.Id,
                PortalId = input.PortalId ?? string.Empty,
                RetMsg = input.RetMsg ?? string.Empty,
                Portal = input.Portal ?? string.Empty,
                PrivacyFlag = input.PrivacyFlag ?? string.Empty
            };
        }
    }
}
