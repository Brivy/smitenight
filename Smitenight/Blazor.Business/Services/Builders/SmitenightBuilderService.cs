using Smitenight.Application.Blazor.Business.Contracts.Services.Builders;
using Smitenight.Application.Blazor.Business.Contracts.Services.Common;
using Smitenight.Domain.Models.Clients.RetrievePlayerClient;
using Smitenight.Domain.Models.Constants.SmiteClient.Responses;
using Smitenight.Domain.Models.Enums.SmiteClient;
using Smitenight.Domain.Models.Models.Players;

namespace Smitenight.Application.Blazor.Business.Services.Builders
{
    public class SmitenightBuilderService : ISmitenightBuilderService
    {
        private readonly IClock _clock;

        public SmitenightBuilderService(IClock clock)
        {
            _clock = clock;
        }

        public Domain.Models.Models.Smitenights.Smitenight Build(PlayerResponse playerResponse, string? pinCode)
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

        public Domain.Models.Models.Smitenights.Smitenight Build(int playerId, string? pinCode)
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
            PlayerResponseConstants.HirezPortal => PortalTypeEnum.Hirez,
            PlayerResponseConstants.SteamPortal => PortalTypeEnum.Steam,
            PlayerResponseConstants.Ps4Portal => PortalTypeEnum.Ps4,
            PlayerResponseConstants.XboxPortal => PortalTypeEnum.Xbox,
            PlayerResponseConstants.SwitchPortal => PortalTypeEnum.Switch,
            PlayerResponseConstants.DiscordPortal => PortalTypeEnum.Discord,
            PlayerResponseConstants.EpicPortal => PortalTypeEnum.Epic,
            _ => PortalTypeEnum.Unknown
        };

        #endregion
    }
}
