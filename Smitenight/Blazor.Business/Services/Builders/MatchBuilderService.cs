﻿using Smitenight.Application.Blazor.Business.Contracts.Services.Builders;
using Smitenight.Domain.Models.Clients.MatchClient;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Providers.SmiteProvider.Contracts.Enums;

namespace Smitenight.Application.Blazor.Business.Services.Builders
{
    public class MatchBuilderService : IMatchBuilderService
    {
        public Match Build(MatchDetailsResponse matchDetailsResponse)
        {
            var matchEntity = new Match
            {
                GameMap = matchDetailsResponse.MapGame,
                GameModeQueue = (GameModeQueueIdEnum)matchDetailsResponse.MatchQueueId,
                MatchDuration = matchDetailsResponse.MatchDuration,
                Name = matchDetailsResponse.Name,
                Region = matchDetailsResponse.Region,
                SmiteId = matchDetailsResponse.Match,
            };

            if (DateTime.TryParse(matchDetailsResponse.EntryDatetime, out var parsedEntryDateTime))
            {
                matchEntity.StartDate = parsedEntryDateTime;
            }

            // If one of them is not zero, we have some kind of match with points
            if (matchDetailsResponse.Team1Score != 0 || matchDetailsResponse.Team2Score != 0)
            {
                matchEntity.TeamOneScore = matchDetailsResponse.Team1Score;
                matchEntity.TeamTwoScore = matchDetailsResponse.Team2Score;
            }

            return matchEntity;
        }
    }
}
