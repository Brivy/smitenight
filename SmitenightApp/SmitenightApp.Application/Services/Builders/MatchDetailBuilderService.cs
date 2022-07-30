using SmitenightApp.Abstractions.Application.Services.Builders;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.MatchResponses;
using SmitenightApp.Domain.Constants.SmiteClient.Responses;
using SmitenightApp.Domain.Enums.Gods;
using SmitenightApp.Domain.Enums.Matches;
using SmitenightApp.Domain.Extensions;
using SmitenightApp.Domain.Models.Matches;

namespace SmitenightApp.Application.Services.Builders
{
    public class MatchDetailBuilderService : IMatchDetailBuilderService
    {
        public MatchDetail Build(MatchDetailsResponse matchDetails)
        {
            return new MatchDetail
            {
                Assists = matchDetails.Assists,
                BotKills = matchDetails.KillsBot,
                DamageDone = matchDetails.DamagePlayer,
                DamageDoneInHand = matchDetails.DamageDoneInHand,
                DamageDoneMagical = matchDetails.DamageDoneMagical,
                DamageDonePhysical = matchDetails.DamageDonePhysical,
                DamageDoneToBots = matchDetails.DamageBot,
                DamageDoneToStructures = matchDetails.StructureDamage,
                DamageMitigated = matchDetails.DamageMitigated,
                DamageTaken = matchDetails.DamageTaken,
                DamageTakenMagical = matchDetails.DamageTakenMagical,
                DamageTakenPhysical = matchDetails.DamageTakenPhysical,
                Deaths = matchDetails.Deaths,
                DistanceTraveled = matchDetails.DistanceTraveled,
                DoubleKills = matchDetails.KillsDouble,
                FireGiantKills = matchDetails.KillsFireGiant,
                FirstBlood = matchDetails.KillsFirstBlood,
                GodRole = ConvertToGodRoleEnum(matchDetails.Role),
                GoldEarned = matchDetails.GoldEarned,
                GoldEarnedPerMinute = matchDetails.GoldPerMinute,
                GoldFuryKills = matchDetails.KillsGoldFury,
                HealingDone = matchDetails.Healing,
                HealingDoneToBots = matchDetails.HealingBot,
                HealingDoneToSelf = matchDetails.HealingPlayerSelf,
                HighestMultiKill = matchDetails.MultiKillMax,
                KillingSpree = matchDetails.KillingSpree,
                LevelReached = matchDetails.FinalMatchLevel,
                MatchTeam = ConvertToMatchTeamEnum(matchDetails.TaskForce),
                ObjectiveAssists = matchDetails.ObjectiveAssists,
                PartyId = matchDetails.PartyId,
                PentaKills = matchDetails.KillsPenta,
                PhoenixKills = matchDetails.KillsPhoenix,
                PlayerKills = matchDetails.KillsPlayer,
                QuadraKills = matchDetails.KillsQuadra,
                SiegeJuggernautKills = matchDetails.KillsSiegeJuggernaut,
                SingleKills = matchDetails.KillsSingle,
                Surrendered = matchDetails.Surrendered.ConvertToBool(),
                TeamId = matchDetails.TeamId != MatchResponseConstants.EmptyResponse ? matchDetails.TeamId : null,
                TotalTimeDead = matchDetails.TimeDeadSeconds,
                TowerKills = matchDetails.TowersDestroyed,
                TripleKills = matchDetails.KillsTriple,
                WardsPlaced = matchDetails.WardsPlaced,
                WildJuggernautKills = matchDetails.KillsWildJuggernaut,
                Winner = matchDetails.WinStatus == MatchResponseConstants.WinnerStatus
            };
        }

        /// <summary>
        /// Converts a god role string to <see cref="GodRoleEnum"/>
        /// </summary>
        /// <param name="godRoles"></param>
        /// <returns></returns>
        private GodRoleEnum ConvertToGodRoleEnum(string godRoles) => godRoles switch
        {
            GodResponseConstants.WarriorRole => GodRoleEnum.Warrior,
            GodResponseConstants.MageRole => GodRoleEnum.Mage,
            GodResponseConstants.HunterRole => GodRoleEnum.Hunter,
            GodResponseConstants.AssassinRole => GodRoleEnum.Assassin,
            GodResponseConstants.GuardianRole => GodRoleEnum.Guardian,
            _ => GodRoleEnum.Unknown
        };

        /// <summary>
        /// Converts a team id int to <see cref="MatchTeamEnum"/>
        /// </summary>
        /// <param name="matchTeamId"></param>
        /// <returns></returns>
        private MatchTeamEnum ConvertToMatchTeamEnum(int matchTeamId) => matchTeamId switch
        {
            MatchResponseConstants.MatchTeamOne => MatchTeamEnum.TeamOne,
            MatchResponseConstants.MatchTeamTwo => MatchTeamEnum.TeamTwo,
            _ => MatchTeamEnum.Unknown
        };
    }
}
