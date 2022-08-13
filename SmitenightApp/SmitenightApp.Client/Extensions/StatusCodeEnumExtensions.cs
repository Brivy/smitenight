using SmitenightApp.Client.Constants;
using SmitenightApp.Domain.Enums.StatusCodes;

namespace SmitenightApp.Client.Extensions
{
    public static class StatusCodeEnumExtensions
    {
        public static string MapUserMessageByStatusCode(this StatusCodeEnum statusCode) => statusCode switch
        {
            StatusCodeEnum.Unknown => UserMessages.UnknownError,
            StatusCodeEnum.Success => UserMessages.Success,
            StatusCodeEnum.PlayerByPlayerNameNotFoundInSmite => UserMessages.PlayerNotFoundInSmite,
            StatusCodeEnum.PlayerHasPrivacyEnabled => UserMessages.PlayerHasPrivacyEnabled,
            StatusCodeEnum.PlayerByPlayerIdNotFoundInSmite => UserMessages.PlayerNotFoundInSmite,
            StatusCodeEnum.SmitenightAlreadyFound => UserMessages.SmitenightAlreadyFound,
            StatusCodeEnum.PlayerHistoryNotFoundInSmite => UserMessages.UnknownError,
            StatusCodeEnum.SmitenightNotFound => UserMessages.UnknownError,
            _ => UserMessages.UnknownError
        };
    }
}
