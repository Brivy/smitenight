using Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.PlayerClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

internal class FriendMapper : Mapper<Friend, FriendDto>
{
    public override FriendDto Map(Friend input)
    {
        return new FriendDto
        {
            AccountId = input.AccountId ?? string.Empty,
            AvatarUrl = input.AvatarUrl ?? string.Empty,
            FriendFlags = input.FriendFlags ?? string.Empty,
            Name = input.Name ?? string.Empty,
            PlayerId = input.PlayerId ?? string.Empty,
            PortalId = input.PortalId ?? string.Empty,
            RetMsg = input.RetMsg ?? string.Empty,
            Status = input.Status ?? string.Empty
        };
    }
}
