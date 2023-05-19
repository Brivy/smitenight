using Smitenight.Application.Blazor.Business.Contracts.Services.Builders;
using Smitenight.Application.Blazor.Business.Contracts.Services.Common;
using Smitenight.Domain.Models.Clients.RetrievePlayerClient;
using Smitenight.Domain.Models.Models.Players;
using Smitenight.Persistence.Data.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Constants;

namespace Smitenight.Application.Blazor.Business.Services.Builders
{
    public class SmitenightBuilderService : ISmitenightBuilderService
    {
        private readonly IClock _clock;

        public SmitenightBuilderService(IClock clock)
        {
            _clock = clock;
        }

        public Persistence.Data.EntityFramework.Entities.Smitenight Build(PlayerResponse playerResponse, string? pinCode)
        {
            return new Domain.Models.Models.Smitenights.Smitenight
            {
                StartDate = _clock.Now(),
                PinCode = pinCode,
                Player = new Player
                {
                    HirezGamerTag = playerResponse.HzGamerTag,
                    HirezPlayerName = playerResponse.HzPlayerName,
                    Level = playerResponse.Level,
                    MasteryLevel = playerResponse.MasteryLevel,
                    PlayerName = playerResponse.HzPlayerName, // Will sometimes take the actual name of the portal account (say, Steam) with playerResponse.Name, we don't want this info
                    PortalType = ConvertToPortalTypeEnum(playerResponse.Platform),
                    SmiteId = playerResponse.Id,
                    PrivacyEnabled = false,
                }
            };
        }

        public Persistence.Data.EntityFramework.Entities.Smitenight Build(int playerId, string? pinCode)
        {
            return new Domain.Models.Models.Smitenights.Smitenight
            {
                StartDate = _clock.Now(),
                PinCode = pinCode,
                PlayerId = playerId
            };
        }

        #region Converters

        public PortalTypeEnum ConvertToPortalTypeEnum(string platform) => platform switch
        {
            PlayerConstants.HirezPortal => PortalTypeEnum.Hirez,
            PlayerConstants.SteamPortal => PortalTypeEnum.Steam,
            PlayerConstants.Ps4Portal => PortalTypeEnum.Ps4,
            PlayerConstants.XboxPortal => PortalTypeEnum.Xbox,
            PlayerConstants.SwitchPortal => PortalTypeEnum.Switch,
            PlayerConstants.DiscordPortal => PortalTypeEnum.Discord,
            PlayerConstants.EpicPortal => PortalTypeEnum.Epic,
            _ => PortalTypeEnum.Unknown
        };

        #endregion
    }
}
