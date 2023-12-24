using Smitenight.Providers.SmiteProvider.Contracts.Models.TeamClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.TeamClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

public class SearchTeamsMapper : Mapper<SearchTeams, SearchTeamsDto>
{
    public override SearchTeamsDto Map(SearchTeams input)
    {
        return new SearchTeamsDto
        {
            Founder = input.Founder ?? string.Empty,
            Name = input.Name ?? string.Empty,
            Players = input.Players,
            RetMsg = input.RetMsg ?? string.Empty,
            Tag = input.Tag ?? string.Empty,
            TeamId = input.TeamId
        };
    }
}
