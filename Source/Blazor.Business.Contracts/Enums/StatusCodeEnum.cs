namespace Smitenight.Application.Core.Business.Contracts.Enums;

public enum StatusCodeEnum
{
    Unknown = 0,
    Success = 1,
    ExceptionDuringSendingRequest = 2,
    ExceptionDuringDeserialization = 3,
    DeserializationEndedInNull = 4,
    PlayerByPlayerNameNotFoundInSmite = 100,
    PlayerHasPrivacyEnabled = 101,
    PlayerByPlayerIdNotFoundInSmite = 102,
    SmitenightAlreadyFound = 103,
    PlayerHistoryNotFoundInSmite = 104,
    SmitenightNotFound = 105,
    PlayerNameTriedWithinCooldownPeriod = 106
}
