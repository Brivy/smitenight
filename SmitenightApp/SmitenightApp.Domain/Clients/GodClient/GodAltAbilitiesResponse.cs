namespace SmitenightApp.Domain.Clients.GodClient
{
    public record class GodAltAbilitiesResponse(
        string AltName,
        string AltPosition,
        string God,
        int GodId,
        int ItemId,
        object RetMsg);
}
