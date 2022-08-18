using SmitenightApp.Abstractions.Application.Services.Builders;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.MatchResponses;
using SmitenightApp.Domain.Enums.SmiteClient;
using SmitenightApp.Domain.Models.Players;

namespace SmitenightApp.Application.Services.Builders
{
    public class PlayerBuilderService : IPlayerBuilderService
    {
        public Player Build(MatchDetailsResponse matchDetailsResponse)
        {
            var player = new Player
            {
                HirezGamerTag = matchDetailsResponse.HzGamerTag,
                HirezPlayerName = matchDetailsResponse.HzPlayerName,
                LastSynchronizedMatchId = matchDetailsResponse.Match,
                Level = matchDetailsResponse.AccountLevel,
                MasteryLevel = matchDetailsResponse.MasteryLevel,
                PlayerName = matchDetailsResponse.PlayerName,
                PrivacyEnabled = false,
            };

            if (!string.IsNullOrWhiteSpace(matchDetailsResponse.PlayerPortalId) && int.TryParse(matchDetailsResponse.PlayerPortalId, out var parsedPlayerPortalId))
            {
                player.PortalType = (PortalTypeEnum)parsedPlayerPortalId;
            }

            if (!string.IsNullOrWhiteSpace(matchDetailsResponse.PlayerId) && int.TryParse(matchDetailsResponse.PlayerId, out var parsedPlayerId))
            {
                player.SmiteId = parsedPlayerId;
            }

            if (!string.IsNullOrWhiteSpace(matchDetailsResponse.PlayerPortalUserId) && long.TryParse(matchDetailsResponse.PlayerPortalUserId, out var parsedPlayerPortalUserId))
            {
                player.SmitePortalUserId = parsedPlayerPortalUserId;
            }
            
            return player;
        }

        public Player BuildAnonymous(MatchDetailsResponse matchDetailsResponse)
        {
            return new Player
            {
                Level = matchDetailsResponse.AccountLevel,
                MasteryLevel = matchDetailsResponse.MasteryLevel,
                PrivacyEnabled = true,
            };
        }
    }
}
