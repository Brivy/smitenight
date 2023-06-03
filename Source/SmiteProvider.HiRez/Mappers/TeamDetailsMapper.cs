using Smitenight.Providers.SmiteProvider.Contracts.Models.TeamClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.TeamClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class TeamDetailsMapper : Mapper<TeamDetails, TeamDetailsDto>
    {
        public override TeamDetailsDto Map(TeamDetails input)
        {
            return new TeamDetailsDto
            {
                TeamId = input.TeamId,
                Players = input.Players,
                Name = input.Name ?? string.Empty,
                Founder = input.Founder ?? string.Empty,
                AvatarUrl = input.AvatarUrl ?? string.Empty,
                FounderId = input.FounderId ?? string.Empty,
                Losses = input.Losses,
                Rating = input.Rating,
                RetMsg = input.RetMsg,
                Tag = input.Tag ?? string.Empty,
                Wins = input.Wins
            };
        }
    }
}
