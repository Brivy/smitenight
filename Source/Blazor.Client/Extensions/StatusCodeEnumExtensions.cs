using Smitenight.Domain.Models.Enums.StatusCodes;
using Smitenight.Presentation.Blazor.Client.Constants;

namespace Smitenight.Presentation.Blazor.Client.Extensions
{
    public static class StatusCodeEnumExtensions
    {
        public static string MapUserMessageByStatusCode(this StatusCodeEnum statusCode) => statusCode switch
        {
            StatusCodeEnum.Success => ServerUserMessages.Success,
            StatusCodeEnum.PlayerByPlayerNameNotFoundInSmite => ServerUserMessages.PlayerNotFoundInSmite,
            StatusCodeEnum.PlayerHasPrivacyEnabled => ServerUserMessages.PlayerHasPrivacyEnabled,
            StatusCodeEnum.PlayerByPlayerIdNotFoundInSmite => ServerUserMessages.PlayerNotFoundInSmite,
            StatusCodeEnum.SmitenightAlreadyFound => ServerUserMessages.SmitenightAlreadyFound,
            StatusCodeEnum.SmitenightNotFound => ServerUserMessages.ActiveSmitenightNotFound,
            StatusCodeEnum.PlayerNameTriedWithinCooldownPeriod => ServerUserMessages.PlayerNotFoundInSmite,
            _ => ServerUserMessages.UnknownError
        };
    }
}
