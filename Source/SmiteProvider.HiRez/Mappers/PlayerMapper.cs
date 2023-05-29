using Smitenight.Providers.SmiteProvider.Contracts.Models.RetrievePlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.RetrievePlayerClient;
using Smitenight.Utilities.Mapper.Common.Contracts;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class PlayerMapper : Mapper<Player, PlayerDto>
    {
        private readonly IMapper<RankedDetails, RankedDetailsDto> _rankedDetailsMapper;

        public PlayerMapper(IMapper<RankedDetails, RankedDetailsDto> rankedDetailsMapper)
        {
            _rankedDetailsMapper = rankedDetailsMapper;
        }

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
                RankedConquest = _rankedDetailsMapper.Map(input.RankedConquest),
                RankedConquestController = _rankedDetailsMapper.Map(input.RankedConquestController),
                RankedDuel = _rankedDetailsMapper.Map(input.RankedDuel),
                RankedDuelController = _rankedDetailsMapper.Map(input.RankedDuelController),
                RankedJoust = _rankedDetailsMapper.Map(input.RankedJoust),
                RankedJoustController = _rankedDetailsMapper.Map(input.RankedJoustController),
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
