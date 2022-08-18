using SmitenightApp.Abstractions.Application.Services.Builders;
using SmitenightApp.Abstractions.Application.Services.Common;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.RetrievePlayerResponses;
using SmitenightApp.Domain.Constants.SmiteClient.Responses;
using SmitenightApp.Domain.Enums.SmiteClient;
using SmitenightApp.Domain.Models.Players;
using SmitenightApp.Domain.Models.Smitenights;

namespace SmitenightApp.Application.Services.Builders
{
    public class SmitenightBuilderService : ISmitenightBuilderService
    {
        private readonly IClock _clock;

        public SmitenightBuilderService(IClock clock)
        {
            _clock = clock;
        }

        public Smitenight Build(PlayerResponse playerResponse, string? pinCode)
        {
            return new Smitenight
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

        public Smitenight Build(int playerId, string? pinCode)
        {
            return new Smitenight
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
