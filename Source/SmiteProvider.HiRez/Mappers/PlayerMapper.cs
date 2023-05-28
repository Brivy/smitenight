using Smitenight.Providers.SmiteProvider.Contracts.Models.RetrievePlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.RetrievePlayerClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class PlayerMapper : Mapper<Player, PlayerDto>
    {
        //private readonly IMapperService _mapperService;

        //public PlayerMapper(IMapperService mapperService)
        //{
        //    _mapperService = mapperService;
        //}

        public override PlayerDto Map(Player input)
        {
            return new PlayerDto
            {
                ActivePlayerId = input.ActivePlayerId,
                AvatarUrl = input.AvatarUrl ?? string.Empty,
                CreatedDatetime = input.CreatedDatetime ?? string.Empty,
                HoursPlayed = input.HoursPlayed,
                Id = input.Id,
                LastLoginDatetime = input.LastLoginDatetime ?? string.Empty,
                Leaves = input.Leaves,
                Level = input.Level,
                Losses = input.Losses,
                MasteryLevel = input.MasteryLevel,
                MergedPlayers = input.MergedPlayers ?? string.Empty,
                MinutesPlayed = input.MinutesPlayed,
                Name = input.Name ?? string.Empty,
                PersonalStatusMessage = input.PersonalStatusMessage ?? string.Empty,
                Platform = input.Platform ?? string.Empty,
                RankStatConquest = input.RankStatConquest,
                RankStatDuel = input.RankStatDuel,
                RankStatJoust = input.RankStatJoust,
                RankStatConquestController = input.RankStatConquestController,
                RankStatDuelController = input.RankStatDuelController,
                RankStatJoustController = input.RankStatJoustController,
                //RankedConquest = _mapperService.Map<RankedDetails, RankedDetailsDto>(input.RankedConquest),
                //RankedConquestController = _mapperService.Map<RankedDetails, RankedDetailsDto>(input.RankedConquestController),
                //RankedDuel = _mapperService.Map<RankedDetails, RankedDetailsDto>(input.RankedDuel),
                //RankedDuelController = _mapperService.Map<RankedDetails, RankedDetailsDto>(input.RankedDuelController),
                //RankedJoust = _mapperService.Map<RankedDetails, RankedDetailsDto>(input.RankedJoust),
                //RankedJoustController = _mapperService.Map<RankedDetails, RankedDetailsDto>(input.RankedJoustController),
                Region = input.Region ?? string.Empty,
                TeamId = input.TeamId,
                TeamName = input.TeamName ?? string.Empty,
                TierConquest = input.TierConquest,
                TierDuel = input.TierDuel,
                TierJoust = input.TierJoust,
                TotalAchievements = input.TotalAchievements,
                TotalWorshippers = input.TotalWorshippers,
                Wins = input.Wins,
                RetMsg = input.RetMsg ?? string.Empty,
                HzGamerTag = input.HzGamerTag ?? string.Empty,
                HzPlayerName = input.HzPlayerName ?? string.Empty
            };
        }
    }
}
