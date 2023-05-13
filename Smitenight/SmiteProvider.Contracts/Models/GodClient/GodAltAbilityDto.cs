namespace Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient
{
    public record class GodAltAbilityDto(
        string AltName,
        string AltPosition,
        string God,
        int GodId,
        int ItemId,
        object RetMsg);
}
