namespace Smitenight.Providers.SmiteProvider.Contracts.Constants;

public static class ItemConstants
{
    // API responses for ItemTypeEnum
    public const string ItemType = "Item";
    public const string ConsumableItemType = "Consumable";
    public const string ActiveItemType = "Active";

    // API responses for RestrictedRolesEnum
    public const string NoRestrictionsRole = "no restrictions";
    public const string HunterRestrictedRole = "hunter";
    public const string GuardianAndHunterAndMageRestrictedRole = "guardian,hunter,mage";
    public const string GuardianAndWarriorRestrictedRole = "guardian,warrior";
    public const string AssassinAndHunterAndMageRestrictedRole = "assassin,hunter,mage";
    public const string AssassinAndWarriorRestrictedRole = "assassin,warrior";
    public const string AssassinAndGuardianAndWarriorRestrictedRole = "assassin,guardian,warrior";

    // API responses for ItemTierEnum
    public const int TierOneItem = 1;
    public const int TierTwoItem = 2;
    public const int TierThreeItem = 3;
    public const int TierFourItem = 4;
}
