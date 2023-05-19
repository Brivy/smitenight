using Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.PlayerClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class PlayerAchievementMapper : Mapper<PlayerAchievement, PlayerAchievementDto>
    {
        public override PlayerAchievementDto Map(PlayerAchievement input)
        {
            return new PlayerAchievementDto
            {
                AssistedKills = input.AssistedKills,
                CampsCleared = input.CampsCleared,
                Deaths = input.Deaths,
                DivineSpree = input.DivineSpree,
                DoubleKills = input.DoubleKills,
                FireGiantKills = input.FireGiantKills,
                FirstBloods = input.FirstBloods,
                GodLikeSpree = input.GodLikeSpree,
                GoldFuryKills = input.GoldFuryKills,
                Id = input.Id,
                ImmortalSpree = input.ImmortalSpree,
                KillingSpree = input.KillingSpree,
                MinionKills = input.MinionKills,
                Name = input.Name ?? string.Empty,
                PentaKills = input.PentaKills,
                PhoenixKills = input.PhoenixKills,
                PlayerKills = input.PlayerKills,
                QuadraKills = input.QuadraKills,
                RampageSpree = input.RampageSpree,
                ShutdownSpree = input.ShutdownSpree,
                SiegeJuggernautKills = input.SiegeJuggernautKills,
                TowerKills = input.TowerKills,
                TripleKills = input.TripleKills,
                UnstoppableSpree = input.UnstoppableSpree,
                WildJuggernautKills = input.WildJuggernautKills,
                RetMsg = input.RetMsg ?? string.Empty
            };
        }
    }
}
