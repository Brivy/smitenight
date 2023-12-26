﻿using Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.PlayerClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

internal class MatchHistoryMapper : Mapper<MatchHistory, MatchHistoryDto>
{
    public override MatchHistoryDto Map(MatchHistory input)
    {
        return new MatchHistoryDto
        {
            ActiveId1 = input.ActiveId1,
            ActiveId2 = input.ActiveId2,
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
            DamageBot = input.DamageBot,
            DamageDoneInHand = input.DamageDoneInHand,
            DamageMitigated = input.DamageMitigated,
            DamageTaken = input.DamageTaken,
            DamageTakenMagical = input.DamageTakenMagical,
            DamageTakenPhysical = input.DamageTakenPhysical,
            Deaths = input.Deaths,
            DistanceTraveled = input.DistanceTraveled,
            FirstBanSide = input.FirstBanSide ?? string.Empty,
            GodId = input.GodId,
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
            ItemId4 = input.ItemId4,
            ItemId5 = input.ItemId5,
            ItemId6 = input.ItemId6,
            KillingSpree = input.KillingSpree,
            MapGame = input.MapGame ?? string.Empty,
            Match = input.Match,
            MatchQueueId = input.MatchQueueId,
            Minutes = input.Minutes,
            MultiKillMax = input.MultiKillMax,
            ObjectiveAssists = input.ObjectiveAssists,
            PlayerName = input.PlayerName ?? string.Empty,
            Region = input.Region ?? string.Empty,
            Skin = input.Skin ?? string.Empty,
            SkinId = input.SkinId,
            Surrendered = input.Surrendered,
            TaskForce = input.TaskForce,
            Team1Score = input.Team1Score,
            Team2Score = input.Team2Score,
            RetMsg = input.RetMsg,
            TimeInMatchSeconds = input.TimeInMatchSeconds,
            WardsPlaced = input.WardsPlaced,
            WinStatus = input.WinStatus ?? string.Empty,
            WinningTaskForce = input.WinningTaskForce,
            Role = input.Role ?? string.Empty,
            Active1 = input.Active1 ?? string.Empty,
            Active2 = input.Active2 ?? string.Empty,
            Active3 = input.Active3 ?? string.Empty,
            Creeps = input.Creeps,
            Damage = input.Damage,
            Gold = input.Gold,
            DamageStructure = input.DamageStructure,
            God = input.God ?? string.Empty,
            Item1 = input.Item1 ?? string.Empty,
            Item2 = input.Item2 ?? string.Empty,
            Item3 = input.Item3 ?? string.Empty,
            Item4 = input.Item4 ?? string.Empty,
            Item5 = input.Item5 ?? string.Empty,
            Item6 = input.Item6 ?? string.Empty,
            Kills = input.Kills,
            Level = input.Level,
            MatchTime = input.MatchTime ?? string.Empty,
            PlayerId = input.PlayerId,
            Queue = input.Queue ?? string.Empty
        };
    }
}
