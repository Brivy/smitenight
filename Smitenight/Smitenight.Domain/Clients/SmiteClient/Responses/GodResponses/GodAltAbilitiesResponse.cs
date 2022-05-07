namespace Smitenight.Domain.Clients.SmiteClient.Responses.GodResponses
{
    public record class GodAltAbilitiesResponse(
        string AltName,
        string AltPosition,
        string God,
        int GodId,
        int ItemId,
        object RetMsg);
}
