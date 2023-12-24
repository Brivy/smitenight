using Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.PlayerClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

public class SearchPlayerMapper : Mapper<SearchPlayer, SearchPlayerDto>
{
    public override SearchPlayerDto Map(SearchPlayer input)
    {
        return new SearchPlayerDto
        {
            PlayerId = input.PlayerId ?? string.Empty,
            Name = input.Name ?? string.Empty,
            RetMsg = input.RetMsg ?? string.Empty,
            PortalId = input.PortalId ?? string.Empty,
            HzPlayerName = input.HzPlayerName ?? string.Empty,
            PrivacyFlag = input.PrivacyFlag ?? string.Empty
        };
    }
}
