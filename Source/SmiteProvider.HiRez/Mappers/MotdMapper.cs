using Smitenight.Providers.SmiteProvider.Contracts.Models.OtherClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.OtherClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

internal class MotdMapper : Mapper<Motd, MotdDto>
{
    public override MotdDto Map(Motd input)
    {
        return new MotdDto
        {
            Description = input.Description ?? string.Empty,
            GameMode = input.GameMode ?? string.Empty,
            Name = input.Name ?? string.Empty,
            StartDateTime = input.StartDateTime ?? string.Empty,
            RetMsg = input.RetMsg ?? string.Empty,
            MaxPlayers = input.MaxPlayers ?? string.Empty,
            Team1GodsCsv = input.Team1GodsCsv ?? string.Empty,
            Team2GodsCsv = input.Team2GodsCsv ?? string.Empty,
            Title = input.Title ?? string.Empty
        };
    }
}
