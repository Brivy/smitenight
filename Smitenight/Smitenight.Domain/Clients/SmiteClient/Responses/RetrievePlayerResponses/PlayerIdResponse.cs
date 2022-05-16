namespace Smitenight.Domain.Clients.SmiteClient.Responses.RetrievePlayerResponses
{
    public record class PlayerIdResponse(
        int PlayerId,
        string Portal,
        string PortalId,
        string PrivacyFlag,
        object RetMsg
    );
}
