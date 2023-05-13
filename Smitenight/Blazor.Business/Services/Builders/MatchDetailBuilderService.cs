﻿using Smitenight.Application.Blazor.Business.Constants;
using Smitenight.Application.Blazor.Business.Contracts.Services.Builders;
using Smitenight.Domain.Models.Clients.MatchClient;
using Smitenight.Domain.Models.Extensions;
using Smitenight.Persistence.Data.Contracts.Enums;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Providers.SmiteProvider.Contracts.Constants;

namespace Smitenight.Application.Blazor.Business.Services.Builders
{
    public class MatchDetailBuilderService : IMatchDetailBuilderService
    {
        public MatchDetail Build(MatchDetailsResponse matchDetailsResponse)
        {
            return new MatchDetail
            {
                Assists = matchDetailsResponse.Assists,
                BotKills = matchDetailsResponse.KillsBot,
                DamageDone = matchDetailsResponse.DamagePlayer,
                DamageDoneInHand = matchDetailsResponse.DamageDoneInHand,
                DamageDoneMagical = matchDetailsResponse.DamageDoneMagical,
                DamageDonePhysical = matchDetailsResponse.DamageDonePhysical,
                DamageDoneToBots = matchDetailsResponse.DamageBot,
                DamageDoneToStructures = matchDetailsResponse.StructureDamage,
                DamageMitigated = matchDetailsResponse.DamageMitigated,
                DamageTaken = matchDetailsResponse.DamageTaken,
                DamageTakenMagical = matchDetailsResponse.DamageTakenMagical,
                DamageTakenPhysical = matchDetailsResponse.DamageTakenPhysical,
                Deaths = matchDetailsResponse.Deaths,
                DistanceTraveled = matchDetailsResponse.DistanceTraveled,
                DoubleKills = matchDetailsResponse.KillsDouble,
                FireGiantKills = matchDetailsResponse.KillsFireGiant,
                FirstBlood = matchDetailsResponse.KillsFirstBlood,
                GodRole = ConvertToGodRoleEnum(matchDetailsResponse.Role),
                GoldEarned = matchDetailsResponse.GoldEarned,
                GoldEarnedPerMinute = matchDetailsResponse.GoldPerMinute,
                GoldFuryKills = matchDetailsResponse.KillsGoldFury,
                HealingDone = matchDetailsResponse.Healing,
                HealingDoneToBots = matchDetailsResponse.HealingBot,
                HealingDoneToSelf = matchDetailsResponse.HealingPlayerSelf,
                HighestMultiKill = matchDetailsResponse.MultiKillMax,
                KillingSpree = matchDetailsResponse.KillingSpree,
                LevelReached = matchDetailsResponse.FinalMatchLevel,
                MatchTeam = ConvertToMatchTeamEnum(matchDetailsResponse.TaskForce),
                ObjectiveAssists = matchDetailsResponse.ObjectiveAssists,
                PartyId = matchDetailsResponse.PartyId,
                PentaKills = matchDetailsResponse.KillsPenta,
                PhoenixKills = matchDetailsResponse.KillsPhoenix,
                PlayerKills = matchDetailsResponse.KillsPlayer,
                QuadraKills = matchDetailsResponse.KillsQuadra,
                SiegeJuggernautKills = matchDetailsResponse.KillsSiegeJuggernaut,
                SingleKills = matchDetailsResponse.KillsSingle,
                Surrendered = matchDetailsResponse.Surrendered.ConvertToBool(),
                TeamId = matchDetailsResponse.TeamId != SmiteConstants.EmptyResponse ? matchDetailsResponse.TeamId : null,
                TotalTimeDead = matchDetailsResponse.TimeDeadSeconds,
                TowerKills = matchDetailsResponse.TowersDestroyed,
                TripleKills = matchDetailsResponse.KillsTriple,
                WardsPlaced = matchDetailsResponse.WardsPlaced,
                WildJuggernautKills = matchDetailsResponse.KillsWildJuggernaut,
                Winner = matchDetailsResponse.WinStatus == MatchConstants.WinnerStatus
            };
        }

        /// <summary>
        /// Converts a god role string to <see cref="GodRoleEnum"/>
        /// </summary>
        /// <param name="godRoles"></param>
        /// <returns></returns>
        private GodRoleEnum ConvertToGodRoleEnum(string godRoles) => godRoles switch
        {
            GodConstants.WarriorRole => GodRoleEnum.Warrior,
            GodConstants.MageRole => GodRoleEnum.Mage,
            GodConstants.HunterRole => GodRoleEnum.Hunter,
            GodConstants.AssassinRole => GodRoleEnum.Assassin,
            GodConstants.GuardianRole => GodRoleEnum.Guardian,
            _ => GodRoleEnum.Unknown
        };

        /// <summary>
        /// Converts a team id int to <see cref="MatchTeamEnum"/>
        /// </summary>
        /// <param name="matchTeamId"></param>
        /// <returns></returns>
        private MatchTeamEnum ConvertToMatchTeamEnum(int matchTeamId) => matchTeamId switch
        {
            MatchConstants.MatchTeamOne => MatchTeamEnum.TeamOne,
            MatchConstants.MatchTeamTwo => MatchTeamEnum.TeamTwo,
            _ => MatchTeamEnum.Unknown
        };
    }
}
