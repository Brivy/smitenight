using SmitenightApp.Abstractions.Application.Services.Builders;
using SmitenightApp.Domain.Clients.MatchClient;
using SmitenightApp.Domain.Constants.SmiteClient.Responses;
using SmitenightApp.Domain.Enums.Gods;
using SmitenightApp.Domain.Enums.Matches;
using SmitenightApp.Domain.Extensions;
using SmitenightApp.Domain.Models.Matches;

namespace SmitenightApp.Application.Services.Builders
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
                TeamId = matchDetailsResponse.TeamId != ResponseConstants.EmptyResponse ? matchDetailsResponse.TeamId : null,
                TotalTimeDead = matchDetailsResponse.TimeDeadSeconds,
                TowerKills = matchDetailsResponse.TowersDestroyed,
                TripleKills = matchDetailsResponse.KillsTriple,
                WardsPlaced = matchDetailsResponse.WardsPlaced,
                WildJuggernautKills = matchDetailsResponse.KillsWildJuggernaut,
                Winner = matchDetailsResponse.WinStatus == MatchResponseConstants.WinnerStatus
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
