using SmitenightApp.Client.Constants;
using SmitenightApp.Domain.Enums.StatusCodes;

namespace SmitenightApp.Client.Extensions
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
            _ => ServerUserMessages.UnknownError
        };
    }
}
