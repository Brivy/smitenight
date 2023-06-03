﻿using Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.MatchClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class MatchDetailsMapper : Mapper<MatchDetails, MatchDetailsDto>
    {
        public override MatchDetailsDto Map(MatchDetails input)
        {
            return new MatchDetailsDto
            {
                AccountLevel = input.AccountLevel,
                ActiveId1 = input.ActiveId1,
                ActiveId2 = input.ActiveId2,
                ActiveId3 = input.ActiveId3,
                ActiveId4 = input.ActiveId4,
                ActivePlayerId = input.ActivePlayerId ?? string.Empty,
                Assists = input.Assists,
                Ban1 = input.Ban1 ?? string.Empty,
                Ban10 = input.Ban10 ?? string.Empty,
                Ban10Id = input.Ban10Id,
                Ban1Id = input.Ban1Id,
                Ban2 = input.Ban2 ?? string.Empty,
                Ban2Id = input.Ban2Id,
                Ban3 = input.Ban3 ?? string.Empty,
                Ban3Id = input.Ban3Id,
                Ban4 = input.Ban4 ?? string.Empty,
                Ban4Id = input.Ban4Id,
                Ban5 = input.Ban5 ?? string.Empty,
                Ban5Id = input.Ban5Id,
                Ban6 = input.Ban6 ?? string.Empty,
                Ban6Id = input.Ban6Id,
                Ban7 = input.Ban7 ?? string.Empty,
                Ban7Id = input.Ban7Id,
                Ban8 = input.Ban8 ?? string.Empty,
                Ban8Id = input.Ban8Id,
                Ban9 = input.Ban9 ?? string.Empty,
                Ban9Id = input.Ban9Id,
                CampsCleared = input.CampsCleared,
                ConquestLosses = input.ConquestLosses,
                ConquestPoints = input.ConquestPoints,
                ConquestTier = input.ConquestTier,
                ConquestWins = input.ConquestWins,
                DamageBot = input.DamageBot,
                DamageDoneInHand = input.DamageDoneInHand,
                DamageDoneMagical = input.DamageDoneMagical,
                DamageDonePhysical = input.DamageDonePhysical,
                DamageMitigated = input.DamageMitigated,
                DamagePlayer = input.DamagePlayer,
                DamageTaken = input.DamageTaken,
                DamageTakenMagical = input.DamageTakenMagical,
                DamageTakenPhysical = input.DamageTakenPhysical,
                Deaths = input.Deaths,
                DistanceTraveled = input.DistanceTraveled,
                DuelLosses = input.DuelLosses,
                DuelPoints = input.DuelPoints,
                DuelTier = input.DuelTier,
                DuelWins = input.DuelWins,
                FinalMatchLevel = input.FinalMatchLevel,
                FirstBanSide = input.FirstBanSide ?? string.Empty,
                GodId = input.GodId,
                GoldEarned = input.GoldEarned,
                GoldPerMinute = input.GoldPerMinute,
                Healing = input.Healing,
                HealingBot = input.HealingBot,
                HealingPlayerSelf = input.HealingPlayerSelf,
                ItemId1 = input.ItemId1,
                Ban11 = input.Ban11 ?? string.Empty,
                Ban11Id = input.Ban11Id,
                ItemId2 = input.ItemId2,
                Ban12 = input.Ban12 ?? string.Empty,
                Ban12Id = input.Ban12Id,
                ItemId3 = input.ItemId3,
                EntryDatetime = input.EntryDatetime ?? string.Empty,
                ItemId4 = input.ItemId4,
                ItemId5 = input.ItemId5,
                ItemId6 = input.ItemId6,
                HasReplay = input.HasReplay ?? string.Empty,
                ItemActive1 = input.ItemActive1 ?? string.Empty,
                ItemActive2 = input.ItemActive2 ?? string.Empty,
                ItemActive3 = input.ItemActive3 ?? string.Empty,
                ItemActive4 = input.ItemActive4 ?? string.Empty,
                ItemPurch1 = input.ItemPurch1 ?? string.Empty,
                ItemPurch2 = input.ItemPurch2 ?? string.Empty,
                ItemPurch3 = input.ItemPurch3 ?? string.Empty,
                ItemPurch4 = input.ItemPurch4 ?? string.Empty,
                ItemPurch5 = input.ItemPurch5 ?? string.Empty,
                ItemPurch6 = input.ItemPurch6 ?? string.Empty,
                JoustLosses = input.JoustLosses,
                JoustPoints = input.JoustPoints,
                JoustTier = input.JoustTier,
                JoustWins = input.JoustWins,
                KillingSpree = input.KillingSpree,
                KillsBot = input.KillsBot,
                KillsDouble = input.KillsDouble,
                KillsFireGiant = input.KillsFireGiant,
                KillsFirstBlood = input.KillsFirstBlood,
                KillsGoldFury = input.KillsGoldFury,
                KillsPenta = input.KillsPenta,
                KillsPhoenix = input.KillsPhoenix,
                KillsPlayer = input.KillsPlayer,
                KillsQuadra = input.KillsQuadra,
                KillsSiegeJuggernaut = input.KillsSiegeJuggernaut,
                KillsSingle = input.KillsSingle,
                KillsTriple = input.KillsTriple,
                KillsWildJuggernaut = input.KillsWildJuggernaut,
                HzGamerTag = input.HzGamerTag,
                MapGame = input.MapGame ?? string.Empty,
                MasteryLevel = input.MasteryLevel,
                Match = input.Match,
                MatchDuration = input.MatchDuration,
                HzPlayerName = input.HzPlayerName,
                PlayerPortalId = input.PlayerPortalId ?? string.Empty,
                MatchQueueId = input.MatchQueueId,
                MergedPlayers = input.MergedPlayers,
                Minutes = input.Minutes,
                MultiKillMax = input.MultiKillMax,
                ObjectiveAssists = input.ObjectiveAssists,
                PartyId = input.PartyId,
                RankStatConquest = input.RankStatConquest,
                Name = input.Name ?? string.Empty,
                RankStatDuel = input.RankStatDuel,
                PlayerId = input.PlayerId ?? string.Empty,
                RankStatJoust = input.RankStatJoust,
                PlayerName = input.PlayerName ?? string.Empty,
                PlayerPortalUserId = input.PlayerPortalUserId ?? string.Empty,
                ReferenceName = input.ReferenceName ?? string.Empty,
                Region = input.Region ?? string.Empty,
                Skin = input.Skin ?? string.Empty,
                SkinId = input.SkinId,
                Surrendered = input.Surrendered,
                TaskForce = input.TaskForce,
                Team1Score = input.Team1Score,
                Team2Score = input.Team2Score,
                TeamId = input.TeamId,
                TeamName = input.TeamName ?? string.Empty,
                RetMsg = input.RetMsg,
                TimeInMatchSeconds = input.TimeInMatchSeconds,
                TowersDestroyed = input.TowersDestroyed,
                WardsPlaced = input.WardsPlaced,
                WinStatus = input.WinStatus ?? string.Empty,
                WinningTaskForce = input.WinningTaskForce,
                Role = input.Role ?? string.Empty,
                StructureDamage = input.StructureDamage,
                TimeDeadSeconds = input.TimeDeadSeconds
            };
        }
    }
}
