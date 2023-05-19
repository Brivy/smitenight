namespace Smitenight.Presentation.Blazor.Client.Constants
{
    public static class ServerUserMessages
    {
        public const string UnknownError = "The developer gods are busy trying to fix this problem. Please try again later.";
        public const string Success = "Something went very right :)";
        public const string PlayerNotFoundInSmite = "The given player is not found in the SMITE database. Please try again in an hour if you have recently changed your in-game playername.";
        public const string PlayerHasPrivacyEnabled = "The user has enabled the privacy flag. With this, we can't start a SMITE night. Please disable the flag before you continue.";
        public const string ActiveSmitenightNotFound = "There is no active SMITE night found for the combination of this player and PIN code.";
        public const string SmitenightAlreadyFound = "We've already found an active SMITE night for this player. Please stop this one first (with the PIN code if enabled) before starting a new one.";
    }
}
