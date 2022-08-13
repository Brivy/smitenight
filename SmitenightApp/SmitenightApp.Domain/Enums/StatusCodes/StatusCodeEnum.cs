﻿namespace SmitenightApp.Domain.Enums.StatusCodes
{
    public enum StatusCodeEnum
    {
        Unknown = 0,
        Success = 1,
        PlayerByPlayerNameNotFoundInSmite = 100,
        PlayerHasPrivacyEnabled = 101,
        PlayerByPlayerIdNotFoundInSmite = 102,
        SmitenightAlreadyFound = 103,
        PlayerHistoryNotFoundInSmite = 104,
        SmitenightNotFound = 105
    }
}
