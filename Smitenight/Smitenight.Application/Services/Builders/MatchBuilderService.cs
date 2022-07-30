using Smitenight.Abstractions.Application.Services.Builders;
using Smitenight.Domain.Clients.SmiteClient.Responses.MatchResponses;
using Smitenight.Domain.Enums.SmiteClient;
using Smitenight.Domain.Models.Matches;

namespace Smitenight.Application.Services.Builders
{
    public class MatchBuilderService : IMatchBuilderService
    {
        public Match Build(MatchDetailsResponse matchDetails)
        {
            var matchEntity = new Match
            {
                GameMap = matchDetails.MapGame,
                GameModeQueue = (GameModeQueueIdEnum)matchDetails.MatchQueueId,
                MatchDuration = matchDetails.MatchDuration,
                Name = matchDetails.Name,
                Region = matchDetails.Region,
                SmiteId = matchDetails.Match,
            };

            if (DateTime.TryParse(matchDetails.EntryDatetime, out var parsedEntryDateTime))
            {
                matchEntity.StartDate = parsedEntryDateTime;
            }

            // If one of them is not zero, we have some kind of match with points
            if (matchDetails.Team1Score != 0 || matchDetails.Team2Score != 0)
            {
                matchEntity.TeamOneScore = matchDetails.Team1Score;
                matchEntity.TeamTwoScore = matchDetails.Team2Score;
            }

            return matchEntity;
        }
    }
}
