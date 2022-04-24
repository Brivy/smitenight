using Smitenight.Providers.SmiteProvider.Contracts.Models.LeagueClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.LeagueClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

public class LeagueSeasonMapper : Mapper<LeagueSeason, LeagueSeasonDto>
{
    public override LeagueSeasonDto Map(LeagueSeason input)
    {
        return new LeagueSeasonDto
        {
            Complete = input.Complete,
            Id = input.Id,
            LeagueDescription = input.LeagueDescription ?? string.Empty,
            Name = input.Name ?? string.Empty,
            RetMsg = input.RetMsg ?? string.Empty,
            Season = input.Season,
            Round = input.Round
        };
    }
}
